using UnityEngine.Video;

public class ControlGenreVideo
{
    private DataGenre _dataGenre;
    private DataGenreLanguage _dataGenreLanguage;
    private GenreVideo _genreVideo;
    //private GenreLanguage _genreLanguage;
    private ControlSettings _controlSettings;

    public ControlGenreVideo(DataGenre dataGenre, DataGenreLanguage dataGenreLanguage, ControlSettings controlSettings)
    {
        _dataGenre = dataGenre;
        _dataGenreLanguage = dataGenreLanguage;
        _genreVideo = new GenreVideo();
        _controlSettings = controlSettings;
    }

    public GenreVideo GetGenreVideo()
    {
        return _genreVideo;
    }

    public void CheckGenreVideo(int idGenre)
    {
        GenreSettings tempGenreSettings;
        GenreLanguage tempGenreLanguage;
        VideoClip tempVideoClip;
        tempGenreSettings = _dataGenre.GetGenreVideo(idGenre);
        tempGenreLanguage = _dataGenreLanguage.GetGenreLanguage(idGenre);
        tempVideoClip = tempGenreLanguage.GetLanguage(_controlSettings.Language);

        _genreVideo.Set(idGenre, tempVideoClip, tempGenreSettings.Audio);
        //_genreLanguage = _dataGenreLanguage.GetItem(idGenre);
    }
}
