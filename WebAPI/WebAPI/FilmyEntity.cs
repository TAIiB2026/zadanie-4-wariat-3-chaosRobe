namespace WebAPI
{
    public class FilmyEntity
    {
        public int id {  get; set; } 
        public string tytul { get; set; }
        public double cena {  get; set; }
        public DateOnly dataPremiery {  get; set; }
    }
    public record FilmyDto(int id, string tytul,
       double cena, DateOnly dataPremiery);
    public record NewFilmyDto(int id, string tytul,
        double cena, DateOnly dataPremiery);
}
