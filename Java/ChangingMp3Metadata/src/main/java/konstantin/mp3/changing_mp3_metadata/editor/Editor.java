package konstantin.mp3.changing_mp3_metadata.editor;

import konstantin.mp3.changing_mp3_metadata.Files.Mp3File;
import konstantin.mp3.changing_mp3_metadata.MenuLib.Action;
import konstantin.mp3.changing_mp3_metadata.MenuLib.Menu;
import konstantin.mp3.changing_mp3_metadata.MenuLib.MenuItem;
import konstantin.mp3.changing_mp3_metadata.commands.*;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class Editor {
    public Mp3File song;
    public String clipboard;
    private CommandHistory history = new CommandHistory();

    public void init() throws IOException {
        Editor editor = this;
        ArrayList<MenuItem> list = new ArrayList<MenuItem>();
        list.add(new MenuItem(CreateAction(new SetSongCommand(this), "Enter the file name: "), "Select song"));
        list.add(new MenuItem(CreateAction(new ShowInfoCommand(this)), "Show data"));
        list.add(new MenuItem(CreateAction(new SetAlbumCommand(this), "Enter the name of the album: "), "Set Album"));
        list.add(new MenuItem(CreateAction(new SetArtistCommand(this), "Enter the name of the artist: "), "Set Artist"));
        list.add(new MenuItem(CreateAction(new SetGenreCommand(this), "Enter the name of the genre: "), "Set Genre"));
        list.add(new MenuItem(CreateAction(new SetYearCommand(this), "Enter the year: "), "Set Year"));
        list.add(new MenuItem(CreateAction(new SaveCommand(this)), "Save"));
        list.add(new MenuItem(editor::undo, "Undo"));
        Menu menu = new Menu(list);
        menu.Start();
    }

    private void Read() {
        Scanner in = new Scanner(System.in);
        clipboard = in.next();
    }

    private Action CreateAction(Command command, String message) {
        return new Action() {
            @Override
            public void Invoke() {
                System.out.println(message);
                Read();
                executeCommand(command);
            }
        };
    }

    private Action CreateAction(Command command) {
        return new Action() {
            @Override
            public void Invoke() {
                executeCommand(command);
            }
        };
    }

    private void executeCommand(Command command) {
        if (command.execute()) {
            history.push(command);
        }
    }

    private void undo() {
        if (history.isEmpty()) return;

        Command command = history.pop();
        if (command != null) {
            command.undo();
        }
    }
}
