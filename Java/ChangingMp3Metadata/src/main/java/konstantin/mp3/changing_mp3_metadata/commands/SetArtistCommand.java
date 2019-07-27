package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;

public class SetArtistCommand extends Command {
    private String _backup;

    public SetArtistCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            CheckEditor();
            backup();
            editor.song.SetArtist(editor.clipboard);
            System.out.println(SuccessMessages.SetArtistCommand);
            return true;
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetArtistCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SetArtistCommand(e));
        }

        return false;
    }

    @Override
    public void backup() {
        try {
            CheckEditor();
            _backup = editor.song.GetMetadata().getArtist();
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetArtistCommand(e));
        }
    }

    @Override
    public void undo() {
        try {
            CheckEditor();
            editor.song.SetArtist(_backup);
            System.out.println(SuccessMessages.UndoCommand);
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetArtistCommand(e));
        }
    }
}
