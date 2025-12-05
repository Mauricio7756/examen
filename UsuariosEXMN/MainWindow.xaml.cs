using System;
using System.Configuration;
using System.Windows;
using ApplicationLogic;

namespace UsuariosEXMN
{
    public partial class MainWindow : Window
    {
        private EmployeesManager manager;

        public MainWindow()
        {
            InitializeComponent();

            string conn = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
            manager = new EmployeesManager(conn);
        }

        private void Insertar_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee
            {
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Title = txtTitle.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                Region = txtRegion.Text,
                PostalCode = txtPostalCode.Text,
                Country = txtCountry.Text,
                HomePhone = txtHomePhone.Text,
                Extension = txtExtension.Text
            };

            manager.Insert(emp);
            lblEstado.Text = "Empleado insertado correctamente.";
        }

        private void Cargar_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                lblEstado.Text = "ID no válido.";
                return;
            }

            Employee? emp = manager.Find(id);

            if (emp == null)
            {
                lblEstado.Text = "Empleado no encontrado.";
                return;
            }

            txtLastName.Text = emp.LastName;
            txtFirstName.Text = emp.FirstName;
            txtTitle.Text = emp.Title;
            txtAddress.Text = emp.Address;
            txtCity.Text = emp.City;
            txtRegion.Text = emp.Region;
            txtPostalCode.Text = emp.PostalCode;
            txtCountry.Text = emp.Country;
            txtHomePhone.Text = emp.HomePhone;
            txtExtension.Text = emp.Extension;

            lblEstado.Text = "Empleado cargado.";
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                lblEstado.Text = "ID no válido.";
                return;
            }

            Employee emp = new Employee
            {
                EmployeeID = id,
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Title = txtTitle.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                Region = txtRegion.Text,
                PostalCode = txtPostalCode.Text,
                Country = txtCountry.Text,
                HomePhone = txtHomePhone.Text,
                Extension = txtExtension.Text
            };

            manager.Update(emp);
            lblEstado.Text = "Empleado actualizado.";
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                lblEstado.Text = "ID no válido.";
                return;
            }

            manager.Delete(id);
            lblEstado.Text = "Empleado eliminado.";
        }
    }
}
