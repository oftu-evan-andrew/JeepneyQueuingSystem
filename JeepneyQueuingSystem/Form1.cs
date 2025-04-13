using System;

namespace JeepneyQueuingSystem
{


    public partial class Form1 : Form
    {
        // Mock database of jeepneys
        List<(string PlateNumber, int PassengerCount)> jeepneyDatabase = new List<(string, int)>
        {
        ("ABC 123", 0),
        ("XYZ 789", 0),
        ("LMN 456", 0),
        ("PQR 001", 0),
        ("UVW 987", 0),
         };

        // Jeepney class to represent a jeepney
        public class Jeepney
        {
            public required string PlateNumber { get; set; }
            public int PassengerCount { get; set; }
        }

        private Queue<(string PlateNumber, int PassengerCount)> jeepneyQueue;
        public Form1()
        {
            InitializeComponent();
            LoadJeepneyData();
            jeepneyQueue = new Queue<(string PlateNumber, int PassengerCount)>(jeepneyDatabase);
            LoadJeepneyData();

        }

        private void UpdateJeepneyDatabase(string plateNumber, int passengerCount)
        {
            for (int i = 0; i < jeepneyDatabase.Count; i++)
            {
                if (jeepneyDatabase[i].PlateNumber == plateNumber)
                {
                    jeepneyDatabase[i] = (plateNumber, passengerCount);
                    break;
                }
            }
        }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = jeepneyDatabase
                .Select(j => new { PlateNumber = j.PlateNumber, PassengerCount = j.PassengerCount })
                .ToList();
        }

        // Method to load jeepney data into the DataGridView upon form load
        private void LoadJeepneyData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = jeepneyDatabase.Select(j => new { PlateNumber = j.PlateNumber, PassengerCount = j.PassengerCount }) // Project data into an anonymous type
        .ToList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdatePassengerCount_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                var selectedRow = dataGridView1.SelectedRows[0];
                string plateNumber = selectedRow.Cells["PlateNumber"].Value.ToString();
                int currentPassengerCount = int.Parse(selectedRow.Cells["PassengerCount"].Value.ToString());

                // Prompt the user for passenger update
                string passengerInput = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Current Passenger Count: {currentPassengerCount}\nEnter passenger update ('+X' to add X passengers, '-X' to subtract X passengers, '0' to skip):",
                    "Passenger Update",
                    "0");

                if (passengerInput.StartsWith("+") || passengerInput.StartsWith("-"))
                {
                    // Add or subtract passengers
                    if (int.TryParse(passengerInput, out int passengerChange))
                    {
                        int updatedPassengerCount = currentPassengerCount + passengerChange;

                        // Ensure passenger count does not go below zero
                        if (updatedPassengerCount < 0)
                        {
                            MessageBox.Show("Passenger count cannot be negative.", "Error");
                        }
                        else
                        {
                            // Update the jeepneyDatabase
                            UpdateJeepneyDatabase(plateNumber, updatedPassengerCount);

                            // Refresh the DataGridView
                            RefreshDataGridView();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid number.", "Error");
                    }
                }
                else if (passengerInput == "0")
                {
                    // Skip update
                    MessageBox.Show("No changes made to the passenger count.", "Information");
                }
                else
                {
                    MessageBox.Show("Invalid input. Please use '+X' or '-X' format.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a jeepney to update.", "No Selection");
            }
        }

        private void btnDepartJeepney_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                var selectedRow = dataGridView1.SelectedRows[0];
                string plateNumber = selectedRow.Cells["PlateNumber"].Value.ToString();

                // Confirm departure
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to mark jeepney {plateNumber} as departed?", "Confirm Departure",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    // Remove the jeepney from the database
                    jeepneyDatabase.RemoveAll(j => j.PlateNumber == plateNumber);

                    // Refresh the DataGridView
                    RefreshDataGridView();

                    // Display departure message
                    MessageBox.Show($"Jeepney {plateNumber} has departed.", "Departure Successful");
                }
                
            }
            else
            {
                MessageBox.Show("Please select a jeepney to mark as departed.", "No Selection");
            }
        }
    }
}

