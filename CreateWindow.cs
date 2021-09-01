using System.Windows.Forms;

public class CreateWindow {
    private MainPage mainPage;
    private Form form;
    public CreateWindow() {

        form = new Form()
        {
            Width = 1080,
            Height = 1080
        };
        mainPage = new MainPage(form);
        form.ShowDialog();
    }
}