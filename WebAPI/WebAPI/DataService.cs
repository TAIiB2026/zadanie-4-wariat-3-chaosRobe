using System.Reflection.Emit;

namespace WebAPI
{
    public class DataService : IDataService
    {

    private static int idGenerator = 1;
    private static List<FilmyEntity> repository = [
    new FilmyEntity{id = idGenerator++,tytul= "Shrek "+idGenerator,cena = 10.00, dataPremiery = new DateOnly(2005, 4, 25) },
    new FilmyEntity{id = idGenerator++,tytul= "Shrek "+idGenerator,cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) },
    new FilmyEntity{id = idGenerator++,tytul= "Shrek "+idGenerator,cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) },
    new FilmyEntity{id = idGenerator++,tytul= "Shrek "+idGenerator,cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) },
    new FilmyEntity{id = idGenerator++,tytul= "Shrek "+idGenerator,cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) }
  ];
        public async Task<IEnumerable<FilmyDto>> GetFilmyDataAsync()
        {
            var filmy = repository.Select(x =>
                new FilmyDto(x.id, x.tytul, x.cena, x.dataPremiery));
            return await Task.FromResult(filmy);
        }
        public async Task<FilmyDto> GetFilmyDataByIdAsync(int id)
        {
            FilmyDto? response;
            FilmyEntity? filmyEntity = repository.Find(x => x.id == id);
            if (filmyEntity is null)
            {
                response = null;
            }
            else
            {
                response = new FilmyDto(filmyEntity.id, filmyEntity.tytul, filmyEntity.cena, filmyEntity.dataPremiery);
            }

            return await Task.FromResult(response);
        }
        public Task<bool> GetFormularzDataAsync(NewFilmyDto newFilmyDto)
        {


       
                var newFilm = new FilmyEntity
                {
                    tytul = newFilmyDto.tytul,
                    cena = newFilmyDto.cena,
                    dataPremiery = newFilmyDto.dataPremiery,
                    id = idGenerator++,
   
                };

                repository.Add(newFilm);
            

            return Task.FromResult(true);
        }
    }
}
