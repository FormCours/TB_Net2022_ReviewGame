// Import des types "SqlClient" dans le projet
using System.Data.SqlClient;


// Connection String for Azure DB
string dbUsername = "della-duck";
string dbPwd = "tb2022-Test123.";

string connectionString = $"Server=tcp:tb2022-bstorm-server.database.windows.net,1433;Initial Catalog=demo-azure;Persist Security Info=False;User ID={dbUsername};Password={dbPwd};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


// Request DB in ADO (Insert)
// **************************
Console.WriteLine("Insert d'une categorie : ");
Console.Write(" - Nom : ");
string catName = Console.ReadLine()!;
Console.Write(" - Desc : ");
string catDesc = Console.ReadLine()!;

// - Création de l'objet "sqlConnection" dans un using
using (SqlConnection sqlConnection = new SqlConnection())
{
    // - Définition de la "Connection String"
    sqlConnection.ConnectionString = connectionString;

    // - Création d'une commande basé sur la connexion
    SqlCommand cmd = sqlConnection.CreateCommand();

    cmd.CommandType = System.Data.CommandType.Text;
    cmd.CommandText = "INSERT INTO [Category] ([Name], [Description])"
                    + " OUTPUT [inserted].[Id]"
                    + " VALUES (@catName, @catDesc);";

    // - Ajout des parametres dans la commandes
    cmd.Parameters.AddWithValue("@catName", catName);
    cmd.Parameters.AddWithValue("@catDesc", !string.IsNullOrWhiteSpace(catDesc)  ? catDesc : DBNull.Value);

    // - Ouvrir la connexion
    sqlConnection.Open();

    // - Execution de la requete SQL
    long catId = (long)cmd.ExecuteScalar();

    // - Affichage Console
    Console.WriteLine($"La categorie '{catName}' a été ajouter avec l'id '{catId}'. ");

    // - Liberation automatique des ressources (Fin du using)
}


// Request DB in ADO (Select)
// **************************
Console.WriteLine("Liste des categories : ");

// - Création de l'objet "sqlConnection" dans un using
using (SqlConnection sqlConnection = new SqlConnection()) { 

    // - Définir la "Connection String"
    sqlConnection.ConnectionString = connectionString;

    // - Création de la commande
    SqlCommand cmd = sqlConnection.CreateCommand();
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.CommandText = "SELECT * FROM Category";

    // - Ouvrir la connexion
    sqlConnection.Open();

    using (SqlDataReader sqlReader = cmd.ExecuteReader())
    {
        while(sqlReader.Read())
        {
            // - Recup un "string"
            string catDbName1 = sqlReader.GetString(sqlReader.GetOrdinal("Name"));
            string catDbName2 = (string)sqlReader["Name"];

            // - Recup un "long"
            long catDbId = (long)sqlReader["Id"];

            // - Recup une valeur nullable
            string? catDbDesc = sqlReader["Description"] is DBNull ? null : (string)sqlReader["Description"];

            // - Affichage des données
            Console.WriteLine($"Id: {catDbId} / Name: {catDbName2} / Desc: {catDbDesc}");
        }
    }
}


