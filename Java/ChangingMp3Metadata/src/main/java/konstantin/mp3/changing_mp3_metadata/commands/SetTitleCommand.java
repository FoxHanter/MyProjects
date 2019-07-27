package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;

public class SetTitleCommand extends Command {
    private String _backup;

    public SetTitleCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            CheckEditor();
            backup();
            editor.song.SetTitle(editor.clipboard);
            System.out.println(SuccessMessages.SetTitleCommand);
            return true;
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetTitleCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SetTitleCommand(e));
        }

        return false;
    }

    @Override
    public void backup() {
        try {
            CheckEditor();
            _backup = editor.song.GetMetadata().getTitle();
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetTitleCommand(e));
        }
    }

    @Override
    public void undo() {
        try {
            CheckEditor();
            editor.song.SetTitle(_backup);
            System.out.println(SuccessMessages.UndoCommand);
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetTitleCommand(e));
        }
    }
}
