namespace MeGeneAPI.Models
{
    public class TableColumn
    {
        /// <summary>
        /// Nombre de la columna
        /// </summary>
        public string? ColumnName { get; set; }
        /// <summary>
        /// Tipo de dato en SQL Server
        /// </summary>
        public string? DataType { get; set; }
        /// <summary>
        /// Longitud para VARCHAR/NVARCHAR
        /// </summary>
        public int? MaxLength { get; set; }
        /// <summary>
        /// Precisión para DECIMAL/NUMERIC
        /// </summary>
        public int? Precision { get; set; }     
        /// <summary>
        /// Escala para DECIMAL/NUMERIC
        /// </summary>
        public int? Scale { get; set; }        
        /// <summary>
        /// Si permite valores NULL
        /// </summary>
        public bool IsNullable { get; set; }    
    }
}
