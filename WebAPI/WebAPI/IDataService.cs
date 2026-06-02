namespace WebAPI
{
    public interface IDataService
    {
        Task<IEnumerable<FilmyDto>> GetFilmyDataAsync();
        Task<FilmyDto> GetFilmyDataByIdAsync(int id);
        Task<bool> GetFormularzDataAsync(NewFilmyDto newFilmyDto);
    }
}
