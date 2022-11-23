namespace ArquivoDoc.Models
{
    public class Arquivos
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Processo { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }

    }
}
