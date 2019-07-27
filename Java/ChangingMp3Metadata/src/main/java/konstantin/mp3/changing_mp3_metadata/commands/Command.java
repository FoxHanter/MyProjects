package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;
import org.blinkenlights.jid3.v2.ID3V2Tag;

public abstract class Command {
    public Editor editor;
    private ID3V2Tag backup;

    Command(Editor editor) {
        this.editor = editor;
    }

    public void backup() {
        try {
            CheckEditor();
            backup = editor.song.GetMetadata();
        } catch (CommandException e) {
            e.printStackTrace();
        }
    }

    public void CheckEditor() throws CommandException {
        if (editor==null||editor.song == null||editor.song.GetMetadata()==null)
            throw new CommandException("Select the song!");
    }

    public void undo() {
        try {
            CheckEditor();
            editor.song.SetMetadata(backup);
        } catch (CommandException e) {
            e.printStackTrace();
        }
    }

    public abstract boolean execute();

    public static class SuccessMessages {

        public static String SetSongCommand(String song) {
            return "Song changed successfully. New song: " + song;
        }

        private static String Success = "changed successfully";
        public static String SaveCommand = "Saved successfully";
        public static String SetAlbumCommand = "Album " + Success;
        public static String SetArtistCommand = "Artist " + Success;
        public static String SetGenreCommand = "Genre " + Success;
        public static String SetTitleCommand = "Title " + Success;
        public static String SetYearCommand = "Year " + Success;
        public static String UndoCommand = "Successful undo";
    }

    public static class UnsuccessMessages {
        public static String SaveCommand(Exception exception) {
            return "Seved unsuccessfully.Error: " + exception.getMessage();
        }

        public static String SetAlbumCommand(Exception exception) {
            return "Album changed unsuccessfully.Error: " + exception.getMessage();
        }

        public static String SetArtistCommand(Exception exception) {
            return "Artist changed unsuccessfully.Error: " + exception.getMessage();
        }

        public static String SetGenreCommand(Exception exception) {
            return "Genre changed unsuccessfully.Error: " + exception.getMessage();
        }

        public static String SetSongCommand(Exception exception) {
            return "Song changed unsuccessfully.Error: " + exception.getMessage();
        }

        public static String SetTitleCommand(Exception exception) {
            return "Title changed unsuccessfully.Error: " + exception.getMessage();
        }

        public static String SetYearCommand(Exception exception) {
            return "Year changed unsuccessfully.Error: " + exception.getMessage();
        }

        public static String ShowInfoCommand(Exception exception) {
            return "Showed info unsuccessfully.Error: " + exception.getMessage();
        }
    }
}
