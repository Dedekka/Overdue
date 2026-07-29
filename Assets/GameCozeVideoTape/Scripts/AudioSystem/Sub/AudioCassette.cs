using System.Collections.Generic;

public class AudioCassette
{
    private AudioCassetteImporter _audioCassetteImporter;

    public AudioCassette(AudioCassetteImporter audioCassetteImporter)
    {
        _audioCassetteImporter = audioCassetteImporter;
    }

    public void SubAudio(List<CassetteObject> cassettes)
    {
        CassetteObject tempCassette;
        for (int i = 0; i < cassettes.Count; i++)
        {
            tempCassette = cassettes[i];
            _audioCassetteImporter.SubCassette(tempCassette);
        }
    }

    public void UnSubAudio(List<CassetteObject> cassettes)
    {
        CassetteObject tempCassette;
        for (int i = 0; i < cassettes.Count; i++)
        {
            tempCassette = cassettes[i];
            _audioCassetteImporter.UnSubCassette(tempCassette);
        }
    }
}