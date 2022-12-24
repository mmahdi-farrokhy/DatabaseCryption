# DatabaseCryption
A program that encrypts and decrypts an Access database

Class DatabaseConnection:
This class makes a connection between the program and the database.
The methods are so:

- ECUsSpecification firstOrDefault(ref ECUsSpecification es, int defaultID)
  This method reads the record from ECUsSpecification table where tha ID equals defaultID.

- AdvanceRemap firstOrDefault(ref AdvanceRemap ar, int defaultID)
  This method reads the record from AdvanceRemap table where tha ID equals defaultID.

- int countInTable(String tbName)
  Counts the records in the table called tbName.

- int lastId(String tbName)
  Returns the ID of the last record in the table called tbName.

- bool updateTable(ECUsSpecification newValue)
  Updates the value of the record in ECUsSpecification table where the record's ID equals newValue's ID

- bool updateTable(AdvanceRemap newValue)
  Updates the value of the record in (AdvanceRemap table where the record's ID equals newValue's ID

- DataTable showOnGridView(ECUsSpecification es)
  Loads the data from ECUsSpecification into a DataTable object in order to show it on a dataGridView

- DataTable showOnGridView(AdvanceRemap es)
  Loads the data from AdvanceRemap into a DataTable object in order to show it on a dataGridView

_______________________________________________________________________________________________________________________
Class Form1
This class the main class of the program where connects the UI to the backend and controls the graphical components.
The methods are so:

- void comboBox1_TextUpdate(object sender, EventArgs e)
  Initializes the table coloumns according to the combobox1 value.

- void button_Encrypt_Click(object sender, EventArgs e)
  When encryption button is clicked on, it encrypts the selected rows and coloumns according to the checkboxes.

- void button_Decrypt_Click(object sender, EventArgs e)
  When decryption button is clicked on, it decrypts the selected rows and coloumns according to the checkboxes.
  
- string encrypt(string clearText, int id)
  Encrypts the clearText that is its input parameter and uses the ID of the record for encryption.
  Here the encryption key is "publicKey", but it could be anything. The point is it should be the same as in "decrypt" method.
  
- string decrypt(string cipherText, int id)
  Decrypts the cipherText that is its input parameter and uses the ID of the record for decryption.
  Here the decryption key is "publicKey", but it could be anything. The point is it should be the same as in "encrypt" method.  