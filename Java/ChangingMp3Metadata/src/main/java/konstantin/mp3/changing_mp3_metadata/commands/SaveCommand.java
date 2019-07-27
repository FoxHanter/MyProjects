package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;

public class SaveCommand extends Command {
    public SaveCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            CheckEditor();
            editor.song.Save();
            System.out.println(SuccessMessages.SaveCommand);
            return true;
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.SaveCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.SaveCommand(e));
        }

        return false;
    }
}
