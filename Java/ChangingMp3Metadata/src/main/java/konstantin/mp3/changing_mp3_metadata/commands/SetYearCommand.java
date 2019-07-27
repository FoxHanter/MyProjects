package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;

public class SetYearCommand extends Command {
    private int _backup;

    public SetYearCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            CheckEditor();
            backup();
            editor.song.SetYear(Integer.parseInt(editor.clipboard));
            System.out.println(SuccessMessages.SetYearCommand);
            return true;
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetYearCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SetYearCommand(e));
        }

        return false;
    }


    @Override
    public void backup() {
        try {
            CheckEditor();
            _backup = editor.song.GetMetadata().getYear();
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetYearCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SetYearCommand(e));
        }
    }

    @Override
    public void undo() {
        try {
            CheckEditor();
            editor.song.SetYear(_backup);
            System.out.println(SuccessMessages.UndoCommand);
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SetYearCommand(e));
        }
    }
}
