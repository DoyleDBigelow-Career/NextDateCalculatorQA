using System.Windows.Forms;

public class MainPage {
    public MainPage(Form form) {
        addDateFormatLabel(form);
        addDateTextBox(form);
        addUseBoundaryValueButton(form);
        addGetNextDateButton(form);
        addNextDateLabel (form);
        addBVAComboBox(form);
        addNextDateOutputLabel (form);
    }

    private void addDateFormatLabel(Form form)
    {
        Label dateFormatLabel = new Label();
        dateFormatLabel.Name = "dateFormatLabel";
        dateFormatLabel.Width = 600;
        dateFormatLabel.Height = 100;
        dateFormatLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dateFormatLabel.Font = new System.Drawing.Font(dateFormatLabel.Font.FontFamily, 60);
        dateFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        dateFormatLabel.Text = "MM/DD/YYYY";
        dateFormatLabel.Location = new System.Drawing.Point(form.Width/2 - dateFormatLabel.Width/2,1*form.Height/10 - dateFormatLabel.Height/2);

        form.Controls.Add(dateFormatLabel);
    }

    private void addNextDateLabel (Form form)
    {
        Label nextDateLabel = new Label();
        nextDateLabel.Name = "nextDateLabel";
        nextDateLabel.Width = 700;
        nextDateLabel.Height = 100;
        nextDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
        nextDateLabel.Font = new System.Drawing.Font(nextDateLabel.Font.FontFamily, 60);
        nextDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        nextDateLabel.Text = "Next Date Output";
        nextDateLabel.Location = new System.Drawing.Point(form.Width/2 - nextDateLabel.Width/2,13*form.Height/40 - nextDateLabel.Height/2);

        form.Controls.Add(nextDateLabel);
    }

    private void addNextDateOutputLabel (Form form)
    {
        Label nextDateOutputLabel = new Label();
        nextDateOutputLabel.Name = "nextDateOutputLabel";
        nextDateOutputLabel.Width = 600;
        nextDateOutputLabel.Height = 100;
        nextDateOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        nextDateOutputLabel.Font = new System.Drawing.Font(nextDateOutputLabel.Font.FontFamily, 75);
        nextDateOutputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        nextDateOutputLabel.BackColor = System.Drawing.Color.White;
        nextDateOutputLabel.Text = "";
        nextDateOutputLabel.Location = new System.Drawing.Point(form.Width/2 - nextDateOutputLabel.Width/2,9*form.Height/20 - nextDateOutputLabel.Height/2);

        form.Controls.Add(nextDateOutputLabel);
    }
    private void addDateTextBox(Form form)
    {
        MaskedTextBox dateTextBox = new MaskedTextBox();
        dateTextBox.Name = "dateTextBox";
        dateTextBox.Width = 600;
        dateTextBox.Font = new System.Drawing.Font(dateTextBox.Font.FontFamily, 85);
        dateTextBox.MaxLength = 10;
        dateTextBox.TextAlign = HorizontalAlignment.Center;
        dateTextBox.TabIndex = 1;
        dateTextBox.Mask = "00/00/0000";
        //dateTextBox.PlaceholderText = "MM/DD/YYYY";
        dateTextBox.Location = new System.Drawing.Point(form.Width/2 - dateTextBox.Width/2,1*form.Height/5 - dateTextBox.Height/2);

        form.Controls.Add(dateTextBox);
    }

    private void addUseBoundaryValueButton(Form form)
    {
        Button useBoundaryValueButton = new Button();
        useBoundaryValueButton.Name = "useBoundaryValueButton";
        useBoundaryValueButton.Width = 200;
        useBoundaryValueButton.Height = 100;
        useBoundaryValueButton.Font = new System.Drawing.Font(useBoundaryValueButton.Font.FontFamily, 18);
        useBoundaryValueButton.Text = "Select BVA\nValue";
        useBoundaryValueButton.Location = new System.Drawing.Point(form.Width/2 - useBoundaryValueButton.Width/2,11*form.Height/20);
        useBoundaryValueButton.TabIndex = 2;
        useBoundaryValueButton.Click += (sender, args) =>
        {
            useBoundaryValueButton.Visible = false;
            form.Controls["bvaComboBox"].Visible = true;
        };
        form.Controls.Add(useBoundaryValueButton);
    }

    private void addGetNextDateButton(Form form)
    {
        Button getNextDateButton = new Button();
        getNextDateButton.Name = "getNextDateButton";
        getNextDateButton.Width = 300;
        getNextDateButton.Height = 150;
        getNextDateButton.Font = new System.Drawing.Font(getNextDateButton.Font.FontFamily, 24);
        getNextDateButton.Text = "Calc Next Date";
        getNextDateButton.Location = new System.Drawing.Point(form.Width/2 - getNextDateButton.Width/2,7*form.Height/10);
        getNextDateButton.TabIndex = 3;
        getNextDateButton.Click += (sender, args) =>
        {
            Date date;
            try {
                date = new Date(form.Controls.Find("dateTextBox", true)[0].Text);
            }
            catch {
                date = null;
                form.Controls.Find("nextDateOutputLabel", true)[0].Text = "Error!";
            }
            if (date != null)
            {
                if (!date.validate())
                    form.Controls.Find("nextDateOutputLabel", true)[0].Text = "Error!";
                else
                {
                    form.Controls.Find("nextDateOutputLabel", true)[0].Text = date.getNext();
                }
            }
            form.Controls["bvaComboBox"].Visible = false;
            form.Controls.Find("useBoundaryValueButton", true)[0].Visible = true;
        };
        form.Controls.Add(getNextDateButton);
    }

    private void addBVAComboBox(Form form) {
        ComboBox bvaComboBox = new ComboBox();
        bvaComboBox.Name = "bvaComboBox";
        string[] bvaDates = System.IO.File.ReadAllLines(@"bvaDates.txt");
        bvaComboBox.Items.AddRange(bvaDates);
        bvaComboBox.Font = new System.Drawing.Font(bvaComboBox.Font.FontFamily, 18);
        bvaComboBox.Width = 200;
        bvaComboBox.Location = new System.Drawing.Point(form.Width/
        2 - bvaComboBox.Width/2,11*form.Height/20);
        bvaComboBox.Visible = false;
        bvaComboBox.SelectionChangeCommitted += (ScrollBarRenderer, ArrangeStartingPosition) =>
        {
            form.Controls.Find("dateTextBox", true)[0].Text = bvaComboBox.GetItemText(bvaComboBox.SelectedItem);
            //bvaComboBox.Visible = false;
            form.Controls.Find("useBoundaryValueButton", true)[0].Visible = true;
        };
        form.Controls.Add(bvaComboBox);
    }
}