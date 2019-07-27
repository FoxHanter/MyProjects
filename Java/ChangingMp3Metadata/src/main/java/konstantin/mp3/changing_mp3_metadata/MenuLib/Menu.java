package konstantin.mp3.changing_mp3_metadata.MenuLib;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class Menu {
    private ArrayList<MenuItem> _menuItems;
    private int _length;

    public Menu(ArrayList<MenuItem> menuItems) {
        _menuItems = menuItems;
        _menuItems.add(new MenuItem(null, "Exit"));
        _length = _menuItems.size();
    }

    private void Print() {
        for (int i = 0; i < _length; i++) {
            System.out.println(i + 1 + ") " + _menuItems.get(i).Title);
        }
    }

    public void Start() throws IOException {
        Scanner in = new Scanner(System.in);
        int k;
        Print();

        while (true) {
            k = in.nextInt();
            if (k != _menuItems.size()) {
                _menuItems.get(k - 1).Action.Invoke();
                Print();
            } else {
                System.exit(0);
            }
        }
    }
}
