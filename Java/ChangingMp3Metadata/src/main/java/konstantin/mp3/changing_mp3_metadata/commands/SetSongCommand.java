package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.Files.Mp3File;
import konstantin.mp3.changing_mp3_metadata.editor.Editor;

public class SetSongCommand extends Command {

    public SetSongCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            editor.song = new Mp3File(editor.clipboard);
            System.out.println(SuccessMessages.SetSongCommand(editor.clipboard));
            return true;
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SetSongCommand(e));
        }

        return false;
    }
}
