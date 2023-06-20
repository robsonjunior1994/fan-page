namespace fan_page.Models
{
    public class Assinatura : ClasseBase
    {
        public int IdDoCriador { get; set; }
        public int IdDoConsumidor { get; set; }
        public double ValorDaAssinatura { get; set; }
    }
}
