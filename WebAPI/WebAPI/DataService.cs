namespace WebAPI
{
    public class DataService : IDataService
    {
        private static int idGenerator = 1;
        private static List<FilmyEntity> repository = [
            new FilmyEntity{id = idGenerator++, tytul= "Shrek "+idGenerator, cena = 10.00, dataPremiery = new DateOnly(2005, 4, 25) },
            new FilmyEntity{id = idGenerator++, tytul= "Shrek "+idGenerator, cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) },
            new FilmyEntity{id = idGenerator++, tytul= "Shrek "+idGenerator, cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) },
            new FilmyEntity{id = idGenerator++, tytul= "Shrek "+idGenerator, cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) },
            new FilmyEntity{id = idGenerator++, tytul= "Shrek "+idGenerator, cena = 10.00, dataPremiery = new DateOnly(2005+idGenerator, 4, 25) }
        ];

        public async Task<IEnumerable<FilmyDto>> GetFilmyDataAsync()
        {
            var filmy = repository.Select(x =>
                new FilmyDto(x.id, x.tytul, x.cena, x.dataPremiery));
            return await Task.FromResult(filmy);
        }

        public async Task<FilmyDto?> GetFilmyDataByIdAsync(int id)
        {
            FilmyEntity? filmyEntity = repository.Find(x => x.id == id);
            if (filmyEntity is null)
            {
                return null;
            }
            return new FilmyDto(filmyEntity.id, filmyEntity.tytul, filmyEntity.cena, filmyEntity.dataPremiery);
        }

        public Task<bool> PostFormularzDataAsync(NewFilmyDto newFilmyDto)
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

        public Task<bool> PutFormularzDataAsync(FilmyDto filmyDto)
        {
            FilmyEntity? film = repository.Find(x => x.id == filmyDto.id);
            if (film is null)
            {
                return Task.FromResult(false);
            }

            film.tytul = filmyDto.tytul;
            film.cena = filmyDto.cena;
            film.dataPremiery = filmyDto.dataPremiery;

            return Task.FromResult(true);
        }
    }
}
