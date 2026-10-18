public class ControlSubGenreAchievement
{
    private ControlSteamAchievement _controlSteamAchievement;
    public ControlSubGenreAchievement(ControlSteamAchievement controlSteamAchievement)
    {
        _controlSteamAchievement = controlSteamAchievement;
    }

    public void SetFullOpera()
    {
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_27);
    }

    public void SetFirstOpera()
    {
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_26);
    }

    public void SetFullSubGenre(Genre genre, int subGenreindex)
    {
        FindSubGenreAchievement(genre, subGenreindex);
    }

    private void FindSubGenreAchievement(Genre genre, int subGenreindex)
    {
        string nameAchievement = "";
        switch (genre)
        {
            case Genre.Триллер:
                //nameAchievement = subGenreindex == 1 ? DataAchievement.ACHIEVEMENT_4 : "";

                if (subGenreindex == 1) { nameAchievement = DataAchievement.ACHIEVEMENT_15; }
                else if (subGenreindex == 2) { nameAchievement = DataAchievement.ACHIEVEMENT_5; }
                else if (subGenreindex == 3) { nameAchievement = DataAchievement.ACHIEVEMENT_7; }
                else if (subGenreindex == 4) { nameAchievement = DataAchievement.ACHIEVEMENT_19; }
                else if (subGenreindex == 5) { nameAchievement = DataAchievement.ACHIEVEMENT_13; }
                else if (subGenreindex == 6) { nameAchievement = DataAchievement.ACHIEVEMENT_8; }
                else if (subGenreindex == 7) { }
                else if (subGenreindex == 8) { nameAchievement = DataAchievement.ACHIEVEMENT_10; }
                else if (subGenreindex == 9) { }
                else if (subGenreindex == 10) { }


                break;
            case Genre.Боевик:

                if (subGenreindex == 1) { nameAchievement = DataAchievement.ACHIEVEMENT_11; }
                else if (subGenreindex == 2) { nameAchievement = DataAchievement.ACHIEVEMENT_12; }
                else if (subGenreindex == 3) { }
                else if (subGenreindex == 4) { nameAchievement = DataAchievement.ACHIEVEMENT_18; }
                else if (subGenreindex == 5) { nameAchievement = DataAchievement.ACHIEVEMENT_14; }
                else if (subGenreindex == 6) { }
                else if (subGenreindex == 7) { }
                else if (subGenreindex == 8) { }
                else if (subGenreindex == 9) { }
                else if (subGenreindex == 10) { nameAchievement = DataAchievement.ACHIEVEMENT_17; }


                break;
            case Genre.Фантастика:
                if (subGenreindex == 1) { }
                else if (subGenreindex == 2) { }
                else if (subGenreindex == 3) { }
                else if (subGenreindex == 4) { nameAchievement = DataAchievement.ACHIEVEMENT_16; }
                else if (subGenreindex == 5) { nameAchievement = DataAchievement.ACHIEVEMENT_23; }
                else if (subGenreindex == 6) { }
                else if (subGenreindex == 7) { nameAchievement = DataAchievement.ACHIEVEMENT_6; }
                else if (subGenreindex == 8) { }
                else if (subGenreindex == 9) { }
                else if (subGenreindex == 10) { }

                break;
            case Genre.Фэнтези:
                nameAchievement = DataAchievement.ACHIEVEMENT_22;
                break;
            case Genre.Приключения:
                break;
            case Genre.Музыка:
                break;
            case Genre.Мультфильм:
                break;
            case Genre.Драма:
                break;
            case Genre.Ужасы:

                nameAchievement = DataAchievement.ACHIEVEMENT_20;


                break;
            case Genre.Комедии:
                nameAchievement = DataAchievement.ACHIEVEMENT_21;

                break;
            case Genre.Историческое:
                nameAchievement = DataAchievement.ACHIEVEMENT_9;
                break;
            case Genre.Детектив:
                nameAchievement = DataAchievement.ACHIEVEMENT_4;
                break;
            case Genre.Порно:
                break;
            case Genre.Хит:
                break;
            case Genre.Опера:
                break;
            default:
                break;
        }

        _controlSteamAchievement.SetAchievement(nameAchievement);
    }
}