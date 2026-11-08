using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace App_511_SWAPI;

public partial class Form1 : Form
{
    private NetworkHelper networkHelper = new();


    public Form1()
    {
        InitializeComponent();

        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

        progressBar1.Visible = false;

        this.Load += Form1_Load;

        //var testPattern = new TestPattern();
        //testPattern.Test();
    }

    private async void Form1_Load(object? sender, EventArgs e)
    {
        AnimateLoading(true);

        await LoadData();

        AnimateLoading(false);
    }

    private async Task LoadData()
    {
        var swapiManager = new SwapiInfoManager(networkHelper);
        var imagesManager = new ImageDataManager(networkHelper);

        InfoBase infoBase = await swapiManager.GetBaseInfo();
        List<PersonData> personData = await swapiManager.GetPeoplesInfo(infoBase.PeoplesUrl);

        List<ImageItem> imageItems = await imagesManager.GetImagesDataInfo();

        personData = DataMerger.MergeData(personData, imageItems);

        FillPersonsList(personData);
    }


    private void FillPersonsList(List<PersonData> persons)
    {
        listBoxPersons.Items.Clear();
        foreach (var item in persons)
        {
            listBoxPersons.Items.Add(item);
        }
    }

    private async Task ShowImage(string imageUrl)
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            client.DefaultRequestHeaders.Add("Referer", "https://starwars.fandom.com/");
            byte[] bytes = await client.GetByteArrayAsync(imageUrl);
            using var vipsImage = NetVips.Image.NewFromBuffer(bytes);
            byte[] pngBuffer = vipsImage.WriteToBuffer(".png");
            using var ms = new MemoryStream(pngBuffer);
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = System.Drawing.Image.FromStream(ms);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error decoding: " + ex.Message);
        }
    }

    private async void listBoxPersons_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxPersons.SelectedItem is PersonData person)
        {
            pictureBox1.Image?.Dispose();
            // Load base "error" or "invisible" (transparent) image.
            AnimateLoading(true);

            var swapiManager = new SwapiInfoManager(networkHelper);

            labelName.Text = person.Name;
            labelBirthDate.Text = string.Concat(
                "Birth year: ", person.BirthYear);

            labelPlanet.Text = string.Concat(
                "Planet: ", await swapiManager
                .GetPlanetName(person.Homeworld));

            labelTransport.Text = string.Concat(
                "Transport: ", await swapiManager
                .GetTransportNames(person));

            await ShowImage(person.ImageUrl);

            AnimateLoading(false);
        }
    }

    private void AnimateLoading(bool isLoading)
    {
        progressBar1.Visible = isLoading;
    }

    private async void buttonSave_Click(object sender, EventArgs e)
    {
        if (listBoxPersons.SelectedItem is not PersonData person)
            return;

        using SaveFileDialog dialog = new SaveFileDialog();

        dialog.Filter = "PDF files (*.pdf)|*.pdf";
        dialog.FileName = $"{person.Name}_info.pdf";

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        try
        {
            buttonSave.Enabled = false;

            var manager = new SwapiInfoManager(networkHelper);

            string planet = await manager.GetPlanetName(person.Homeworld);
            string transport = await manager.GetTransportNames(person);

            byte[]? imageBytes = null;

            if (pictureBox1.Image != null)
            {
                using Bitmap bitmap = new Bitmap(pictureBox1.Image);
                using MemoryStream ms = new MemoryStream();

                bitmap.Save(ms, ImageFormat.Png);

                imageBytes = ms.ToArray();
            }

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Text("CHARACTER DOSSIER")
                        .FontSize(24)
                        .Bold()
                        .AlignCenter();

                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            column.Spacing(12);

                            column.Item()
                                .Text(person.Name.ToUpper())
                                .FontSize(20)
                                .Bold();

                            if (imageBytes != null)
                            {
                                column.Item()
                                    .AlignCenter()
                                    .Width(200)
                                    .Height(200)
                                    .Image(imageBytes)
                                    .FitArea();
                            }

                            column.Item().Text($"Name: {person.Name}");
                            column.Item().Text($"Homeworld: {planet}");
                            column.Item().Text($"Birth year: {person.BirthYear}");

                            column.Item().Text($"Height: {person.Height} cm");
                            column.Item().Text($"Mass: {person.Mass} kg");

                            column.Item().Text($"Hair color: {person.HairColor}");
                            column.Item().Text($"Skin color: {person.SkinColor}");
                            column.Item().Text($"Eye color: {person.EyeColor}");

                            column.Item()
                                .PaddingTop(10)
                                .Text("TRANSPORT")
                                .FontSize(16)
                                .Bold();

                            column.Item().Text(transport);
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text($"STAR WARS DATABASE | {DateTime.Now:dd.MM.yyyy}");
                });
            })
            .GeneratePdf(dialog.FileName);


            Process.Start(new ProcessStartInfo
            {
                FileName = dialog.FileName,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(
                ex.ToString(),
                "PDF Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            buttonSave.Enabled = true;
        }
    }
}
