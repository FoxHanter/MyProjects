package konstantin.mp3.changing_mp3_metadata.Files;

import org.blinkenlights.jid3.ID3Exception;
import org.blinkenlights.jid3.MP3File;
import org.blinkenlights.jid3.MediaFile;
import org.blinkenlights.jid3.v2.ID3V2Tag;

import java.io.File;

public class Mp3File
{
    private MediaFile _song;
    private ID3V2Tag _metadata;

    public Mp3File(String fileName) throws Exception {

            File oSourceFile = new File(fileName);
            _song = new MP3File(oSourceFile);
            _metadata = _song.getID3V2Tag();
    }

    public ID3V2Tag GetMetadata(){
        return _metadata;
    }

    public String Print() {
        String output = null;

        try {
            output = String.format(" Album:%s%n Artist:%s%n Genre:%s%n Year:%d%n", _metadata.getAlbum(),_metadata.getArtist(),_metadata.getGenre(),_metadata.getYear());
        } catch (ID3Exception e) {
            e.printStackTrace();
        }
        return  output;
    }

    public void SetMetadata(ID3V2Tag metadata) {
        _metadata=metadata;
    }

    public void Save() {
        _song.setID3Tag(_metadata);

        try {
            _song.sync();
        } catch (ID3Exception e) {
            e.printStackTrace();
        }
    }

    public void SetAlbum(String album) {
        try {
            _metadata.setAlbum(album);
        }
        catch (ID3Exception e) {
            e.printStackTrace();
        }
    }

    public void SetArtist(String artist) {
        try {
            _metadata.setArtist(artist);
        }
        catch (ID3Exception e) {
            e.printStackTrace();
        }
    }

    public void SetGenre(String genre) {
        try {
            _metadata.setGenre(genre);
        }
        catch (ID3Exception e) {
            e.printStackTrace();
        }
    }

    public void SetTitle(String title) {
        try {
            _metadata.setAlbum(title);
        }
        catch (ID3Exception e) {
            e.printStackTrace();
        }
    }

    public void SetYear(int year) {
        try {
            _metadata.setYear(year);
        }
        catch (ID3Exception e) {
            e.printStackTrace();
        }
    }
}
