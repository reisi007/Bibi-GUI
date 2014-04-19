package at.reisisoft.bibigui.ui;

import java.awt.*;

public interface IShowable {
    default public void show() {
        show(null);
    }

     public void show(Frame component);

}
