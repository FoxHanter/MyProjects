package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;

public class SetAlbumCommand extends Command {
    private String _backup;

    public SetAlbumCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            CheckEditor();
            backup();
            editor.song.SetAlbum(editor.clipboard);
            System.out.println(SuccessMessages.SetAlbumCommand);
            return true;
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetAlbumCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SetAlbumCommand(e));
        }

        return false;
    }

    @Override
    public void backup() {
        try {
            CheckEditor();
            _backup = editor.song.GetMetadata().getAlbum();
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetAlbumCommand(e));
        }
    }

    @Override
    public void undo() {
        try {
            CheckEditor();
            editor.song.SetAlbum(_backup);
            System.out.println(SuccessMessages.UndoCommand);
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetAlbumCommand(e));
        }
    }
}
