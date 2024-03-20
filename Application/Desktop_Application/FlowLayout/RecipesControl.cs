using MyApplication.Domain.Enums;
using MyApplication.Domain.Recipes;
using MyApplication.Domain.Services;
using MyApplication.Domain.Users;
using MyApplication.Infrastructure.Databases;

namespace Desktop_Application.FlowLayout
{
    public partial class RecipesControl : UserControl
    {
        private readonly RecipeServices recipeServices;
        private readonly User user;
        private byte[] filename = null;

        public RecipesControl(User user)
        {
            InitializeComponent();
            try
            {
                recipeServices = new RecipeServices(new RecipeRepository());
                this.user = user;
                FillDataGrid();
                FillComboboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataGrid()
        {
            dgvRecipes.DataSource = recipeServices.ViewAllRecipes();
            dgvRecipes.Columns["image"].Visible = false;
        }

        private void FillDataGrid(List<Recipe> recipes)
        {
            dgvRecipes.DataSource = recipes;
        }

        private void ClearRecipeData()
        {
            tbxRecipeId.Clear();
            tbxModifyRecipename.Clear();
            tbxRecipeName.Clear();
            rtbxModifyIngredients.Clear();
            rtbxIngredients.Clear();
            rtbxModifyDesc.Clear();
            rtbxDesc.Clear();
            rtbxModifySteps.Clear();
            rtbxSteps.Clear();
            cmbxModifyRecipeType.SelectedIndex = 0;
            cmbxRecipeType.SelectedIndex = 0;
            nudModifyCookTime.Value = 1;
            nudCookTime.Value = 1;
            nudModifyPrepTime.Value = 1;
            nudPrepTime.Value = 1;
            filename = null;
            tbxModifyCuisineType.Clear();
            tbxCuisineType.Clear();
            rtbxModifyServingSuggestion.Clear();
            rtbxServingSuggestion.Clear();
            chbxModAlcohol.Checked = false;
            chbxAlcohol.Checked = false;
            tbxModDrinkType.Clear();
            tbxDrinkType.Clear();
            tbxModGlassType.Clear();
            tbxGlassType.Clear();
            tbxDessertType.Clear();
            tbxModDessertType.Clear();
            tbxTopping.Clear();
            tbxModTopping.Clear();
            rtbxModServMethod.Clear();
            rtbxServMethod.Clear();
            lblImageName.Text = "No Image...";
            lblImageUpload.Text = "No Image...";
        }

        private void FillModifyRecipe(Recipe r)
        {
            tbxRecipeId.Text = r.recipeid.ToString();
            tbxModifyRecipename.Text = r.name;
            rtbxModifyIngredients.Text = r.Ingredients;
            rtbxModifyDesc.Text = r.desc;
            rtbxModifySteps.Text = r.steps;
            cmbxModifyRecipeType.SelectedItem = r.recipetype;
            nudModifyCookTime.Value = r.cooktime;
            nudModifyPrepTime.Value = r.preptime;
            chbxShown.Checked = r.shown;

            if (r.image != null)
            {
                filename = r.image;
                lblImageName.Text = $"{ValidationServices.RemoveWhitespace(r.name)}.jpg";
            }
            else
            {
                lblImageName.Text = "No Image...";
            }

            switch (r)
            {
                case MainCourse m:
                    tbxModifyCuisineType.Text = m.cuisineType;
                    rtbxModifyServingSuggestion.Text = m.servingSuggestion;
                    foreach (var d in m.dietaryType)
                    {
                        int index = chklstModifyDiets.Items.IndexOf(d);
                        if (index != -1)
                        {
                            chklstModifyDiets.SetItemChecked(index, true);
                        }
                    }
                    break;
                case Drink d:
                    chbxModAlcohol.Checked = d.alcoholic;
                    tbxModDrinkType.Text = d.drinkType;
                    tbxModGlassType.Text = d.glassType;
                    break;
                case Dessert d:
                    tbxModDessertType.Text = d.dessertType;
                    tbxModTopping.Text = d.topping;
                    rtbxModServMethod.Text = d.servingMethod;
                    break;
            }
        }

        private void FillComboboxes()
        {
            chklstDiets.Items.Clear();
            chklstModifyDiets.Items.Clear();
            Diet[] diets = (Diet[])Enum.GetValues(typeof(Diet));
            foreach (var d in diets)
            {
                chklstDiets.Items.Add(d);
                chklstModifyDiets.Items.Add(d);
            }
            recipetype[] recipetypes = (recipetype[])Enum.GetValues(typeof(recipetype));
            cmbxModifyRecipeType.DataSource = recipetypes;
            cmbxRecipeType.DataSource = recipetypes;
            List<string> filters = new List<string>(Enum.GetNames(typeof(recipetype)));
            filters.Insert(0, "-");
            cmbxFilter.DataSource = filters;
        }

        private void dgvRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var SelectedRecipe = (int)dgvRecipes.SelectedRows[0].Cells["recipeId"].Value;
                FillModifyRecipe(recipeServices.GetRecipeById(SelectedRecipe));
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectedRecipe = (int)dgvRecipes.SelectedRows[0].Cells["recipeId"].Value;
                FillModifyRecipe(recipeServices.GetRecipeById(SelectedRecipe));
                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] ImageToByteArray(Image img)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void btnModifyImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opnfd = new OpenFileDialog();
                opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (opnfd.ShowDialog() == DialogResult.OK)
                {
                    Image selectedImage = Image.FromFile(opnfd.FileName);
                    filename = ImageToByteArray(selectedImage);
                    lblImageName.Text = System.IO.Path.GetFileName(opnfd.FileName);
                    selectedImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opnfd = new OpenFileDialog();
                opnfd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (opnfd.ShowDialog() == DialogResult.OK)
                {
                    Image selectedImage = Image.FromFile(opnfd.FileName);
                    filename = ImageToByteArray(selectedImage);
                    lblImageUpload.Text = System.IO.Path.GetFileName(opnfd.FileName);
                    selectedImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbxModifyRecipeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxModifyRecipeType.SelectedIndex == 0)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }
            else if (cmbxModifyRecipeType.SelectedIndex == 1)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
            else if (cmbxModifyRecipeType.SelectedIndex == 2)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
            }
        }

        private void cmbxRecipeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxRecipeType.SelectedIndex == 0)
            {
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                groupBox6.Visible = true;
            }
            else if (cmbxRecipeType.SelectedIndex == 1)
            {
                groupBox4.Visible = false;
                groupBox5.Visible = true;
                groupBox6.Visible = false;
            }
            else if (cmbxRecipeType.SelectedIndex == 2)
            {
                groupBox4.Visible = true;
                groupBox5.Visible = false;
                groupBox6.Visible = false;
            }
        }

        private void btnCreateRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Recipe Added!";
                int userid = user.userId;
                string name = tbxRecipeName.Text;
                string ing = rtbxIngredients.Text;
                string steps = rtbxSteps.Text;
                string desc = rtbxDesc.Text;
                recipetype RType;
                Enum.TryParse(cmbxRecipeType.SelectedValue.ToString(), out RType);
                int cook = (int)nudCookTime.Value;
                int prep = (int)nudPrepTime.Value;
                string[] notEmpty = new string[] { name, ing, steps, desc };

                switch (cmbxRecipeType.SelectedIndex)
                {
                    case 0:
                        string cui = tbxCuisineType.Text;
                        string ser = rtbxServingSuggestion.Text;
                        notEmpty.Concat(new string[] { cui, ser });
                        List<Diet> diets = new List<Diet>();
                        foreach (Diet d in chklstDiets.CheckedItems)
                        {
                            diets.Add(d);
                        }
                        if (ValidationServices.TextBoxValidation(notEmpty))
                        {
                            MainCourse m = new MainCourse(
                                name, userid, desc, RType, ing, prep, cook, steps, true, filename, cui, diets, ser);
                            recipeServices.CreateRecipe(m);
                            FinishModify(msg);
                        }
                        else
                        {
                            MessageBox.Show("Some or all fields are empty");
                        }
                        break;
                    case 1:
                        string dri = tbxDrinkType.Text;
                        string gla = tbxGlassType.Text;
                        bool alc = chbxAlcohol.Checked;
                        notEmpty.Concat(new string[] { dri, gla });
                        if (ValidationServices.TextBoxValidation(notEmpty))
                        {
                            Drink d = new Drink(
                                name, userid, desc, ing, RType, prep, cook, steps, true, filename, alc, dri, gla);
                            recipeServices.CreateRecipe(d);
                            FinishModify(msg);
                        }
                        else
                        {
                            MessageBox.Show("Some or all fields are empty");
                        }
                        break;
                    case 2:
                        string des = tbxDessertType.Text;
                        string top = tbxTopping.Text;
                        string serv = rtbxServMethod.Text;
                        notEmpty.Concat(new string[] { des, top, serv });
                        if (ValidationServices.TextBoxValidation(notEmpty))
                        {
                            Dessert d = new Dessert(
                                name, userid, desc, RType, ing, prep, cook, steps, true, filename, des, serv, top);
                            recipeServices.CreateRecipe(d);
                            FinishModify(msg);
                        }
                        else
                        {
                            MessageBox.Show("Some or all fields are empty");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModifyDetails(Recipe rec, string name, string ing, string steps, int cook, int prep, string desc, bool shown)
        {
            rec.name = name;
            rec.Ingredients = ing;
            rec.steps = steps;
            rec.desc = desc;
            rec.cooktime = cook;
            rec.preptime = prep;
            rec.shown = shown;
            rec.image = filename;
        }

        private void FinishModify(string message)
        {
            MessageBox.Show(message);
            FillDataGrid();
            FillComboboxes();
            ClearRecipeData();
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnModifyRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show(this, "Are you sure you want to modify this recipe", "Modify recipe", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        string msg = "Recipe Updated";
                        int id = Convert.ToInt32(tbxRecipeId.Text);
                        Recipe rec = recipeServices.GetRecipeById(id);
                        string name = tbxModifyRecipename.Text;
                        string ing = rtbxModifyIngredients.Text;
                        string steps = rtbxModifySteps.Text;
                        string desc = rtbxModifyDesc.Text;
                        bool shown = chbxShown.Checked;
                        //recipetype RType;
                        //Enum.TryParse(cmbxModifyRecipeType.SelectedValue.ToString(), out RType);
                        int cook = (int)nudModifyCookTime.Value;
                        int prep = (int)nudModifyPrepTime.Value;

                        string[] notEmpty = new string[] { name, ing, steps, desc };
                        switch (rec)
                        {
                            case MainCourse m:
                                string cui = tbxModifyCuisineType.Text;
                                string ser = rtbxModifyServingSuggestion.Text;
                                notEmpty.Concat(new string[] { cui, ser });
                                List<Diet> diets = new List<Diet>();
                                foreach (Diet d in chklstModifyDiets.CheckedItems)
                                {
                                    diets.Add(d);
                                }
                                if (ValidationServices.TextBoxValidation(notEmpty))
                                {
                                    ModifyDetails(m, name, ing, steps, cook, prep, desc, shown);
                                    m.cuisineType = cui;
                                    m.servingSuggestion = ser;
                                    m.dietaryType = diets;
                                    recipeServices.UpdateRecipe(m);
                                    FinishModify(msg);
                                }
                                else
                                {
                                    MessageBox.Show("Some or all fields are empty");
                                }
                                break;
                            case Drink d:
                                string dri = tbxModDrinkType.Text;
                                string gla = tbxModGlassType.Text;
                                bool alc = chbxModAlcohol.Checked;
                                notEmpty.Concat(new string[] { dri, gla });
                                if (ValidationServices.TextBoxValidation(notEmpty))
                                {
                                    ModifyDetails(d, name, ing, steps, cook, prep, desc, shown);
                                    d.drinkType = dri;
                                    d.glassType = gla;
                                    d.alcoholic = alc;
                                    recipeServices.UpdateRecipe(d);
                                    FinishModify(msg);
                                }
                                else
                                {
                                    MessageBox.Show("Some or all fields are empty");
                                }
                                break;
                            case Dessert d:
                                string des = tbxModDessertType.Text;
                                string top = tbxModTopping.Text;
                                string serv = rtbxModServMethod.Text;
                                notEmpty.Concat(new string[] { des, top, serv });
                                if (ValidationServices.TextBoxValidation(notEmpty))
                                {
                                    ModifyDetails(d, name, ing, steps, cook, prep, desc, shown);
                                    d.dessertType = des;
                                    d.topping = top;
                                    d.servingMethod = serv;
                                    recipeServices.UpdateRecipe(d);
                                    FinishModify(msg);
                                }
                                else
                                {
                                    MessageBox.Show("Some or all fields are empty");
                                }
                                break;
                        }
                        break;
                    case DialogResult.No: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string NameSearch = tbxSearch.Text;
                List<Recipe> filteredproducts = new List<Recipe>();
                foreach (var recipe in recipeServices.ViewAllRecipes())
                {
                    if (string.IsNullOrEmpty(NameSearch) || recipe.name.Contains(NameSearch, (StringComparison)5))
                    {
                        if (cmbxFilter.Text == recipe.recipetype.ToString())
                        {
                            filteredproducts.Add(recipe);
                        }
                        else if (cmbxFilter.Text == "-")
                        {
                            filteredproducts.Add(recipe);
                        }
                    }
                }
                FillDataGrid(filteredproducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show(this, "Are you sure you want to hide this Recipe?", "Hide Recipe", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        int SelectedRecipe = (int)dgvRecipes.SelectedRows[0].Cells["recipeId"].Value;
                        recipeServices.DeleteRecipes(SelectedRecipe);
                        MessageBox.Show("Recipe is now hidden");
                        FillDataGrid();
                        break;
                    case DialogResult.No: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
