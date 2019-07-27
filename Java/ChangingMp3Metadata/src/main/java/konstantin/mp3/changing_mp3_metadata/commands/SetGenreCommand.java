package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;

public class SetGenreCommand extends Command {
    private String _backup;

    public SetGenreCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            CheckEditor();
            backup();
            editor.song.SetGenre(editor.clipboard);
            System.out.println(SuccessMessages.SetGenreCommand);
            return true;
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetGenreCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SetGenreCommand(e));
        }

        return false;
    }

    @Override
    public void backup() {
        try {
            CheckEditor();
            _backup = editor.song.GetMetadata().getGenre();
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetGenreCommand(e));
        }
    }

    @Override
    public void undo() {
        try {
            CheckEditor();
            editor.song.SetGenre(_backup);
            System.out.println(SuccessMessages.UndoCommand);
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetGenreCommand(e));
        }
    }
}
