using System.Collections.Generic;

public class AudioRack
{
    private AudioRackImporter _audioRackImporter;

    public AudioRack(AudioRackImporter audioCassetteImporter)
    {
        _audioRackImporter = audioCassetteImporter;
    }

    public void SubAudio(List<TestRack> racks)
    {
        TestRack testRack;
        for (int i = 0; i < racks.Count; i++)
        {
            testRack = racks[i];
            _audioRackImporter.SubCassette(testRack);
        }
    }

    public void UnSubAudio(List<TestRack> racks)
    {
        TestRack testRack;
        for (int i = 0; i < racks.Count; i++)
        {
            testRack = racks[i];
            _audioRackImporter.UnSubCassette(testRack);
        }
    }
}