using System;
using UnityEngine;

public class ControlGenreVideo
{
    private DataGenre _dataGenre;
    private GenreVideo _genreVideo;

    public ControlGenreVideo(DataGenre dataGenre)
    {
        _dataGenre = dataGenre;
    }

    public GenreVideo GetGenreVideo()
    {
        return _genreVideo;
    }

    public void CheckGenreVideo(int idGenre)
    {
        _genreVideo = _dataGenre.GetGenreVideo(idGenre);
    }
}
