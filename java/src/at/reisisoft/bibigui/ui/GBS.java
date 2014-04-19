package at.reisisoft.bibigui.ui;

import at.reisisoft.bibigui.BisectResult;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class GBS implements IShowable {
    private JButton bGOOD;
    private JButton bBAD;
    private JButton bSKIP;
    private JPanel GBSpanel;
    private BisectResult result = null;
    JWindow jWindow;
    MouseAdapter gListener = new MouseAdapter() {
        @Override
        public void mouseClicked(MouseEvent e) {
            if (SwingUtilities.isLeftMouseButton(e)) {
                result = BisectResult.Good;
                jWindow.setVisible(false);
                jWindow.dispose();
            }
            super.mouseClicked(e);
        }
    };
    MouseAdapter bListener = new MouseAdapter() {
        @Override
        public void mouseClicked(MouseEvent e) {
            if (SwingUtilities.isLeftMouseButton(e)) {
                result = BisectResult.Bad;
                jWindow.setVisible(false);
                jWindow.dispose();
            }
            super.mouseClicked(e);
        }
    };

    MouseAdapter sListener = new MouseAdapter() {
        @Override
        public void mouseClicked(MouseEvent e) {
            if (SwingUtilities.isLeftMouseButton(e)) {
                result = BisectResult.Skip;
                jWindow.setVisible(false);
                jWindow.dispose();
            }
            super.mouseClicked(e);
        }
    };

    public BisectResult getResult() {
        return result;
    }


    @Override
    public void show(Frame component) {
        JWindow jWindow;
        bGOOD.addMouseListener(gListener);
        bBAD.addMouseListener(bListener);
        bSKIP.addMouseListener(sListener);
        if (component == null)
            jWindow = new JWindow();
        else
            jWindow = new JWindow(component);
        jWindow.add(GBSpanel);
        Dimension dimension = new Dimension(300, 200);
        jWindow.setMinimumSize(dimension);
        jWindow.setMaximumSize(dimension);
        jWindow.pack();
        jWindow.setLocationRelativeTo(component);
        this.jWindow = jWindow;
        jWindow.setVisible(true);
    }
}



