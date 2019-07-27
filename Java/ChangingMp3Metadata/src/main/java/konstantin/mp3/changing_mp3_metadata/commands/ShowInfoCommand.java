package konstantin.mp3.changing_mp3_metadata.commands;

import konstantin.mp3.changing_mp3_metadata.editor.Editor;

import static java.lang.System.out;

public class ShowInfoCommand extends Command {
    public ShowInfoCommand(Editor editor) {
        super(editor);
    }

    @Override
    public boolean execute() {
        try {
            CheckEditor();
            out.println(editor.song.Print());
        } catch (CommandException e) {
            System.out.println(UnsuccessMessages.ShowInfoCommand(e));
        } catch (Exception e) {
            System.out.println(UnsuccessMessages.ShowInfoCommand(e));
        }

        return false;
    }
}
