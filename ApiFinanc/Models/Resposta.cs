namespace ApiFinanc.Models
{
    public class Resposta
    {
        public int id_pergunta { get; set; }
        public int id_resposta { get; set; }
        public string des_resposta { get; set; }
        public int peso { get; set; }

        public Resposta(int id_perg, int id_resp, string descricao, int pes)
        {
            this.id_pergunta = id_perg;
            this.id_resposta = id_resp;
            this.des_resposta = descricao;
            this.peso = pes;
        }
    }
}