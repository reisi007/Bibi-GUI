package at.reisisoft.bibigui.ui;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.LinkedList;
import java.util.List;

public class MainUI implements IShowable {
    private JButton repoFolderOnDiskButton;
    private JTextArea textAreaOutput;
    private JTextField tbRepoFolderOnDisk;
    private JTextField repoOnlineTextField;
    private JButton startButton;
    private JButton checkSetupButton;
    private JProgressBar progressBar1;
    private JComboBox fromComboBox;
    private JComboBox zoComboBox;
    private JPanel mainUIJPanel;

    public MainUI() {

    }

    public void show() {
        show(null);
    }

    /**
     * @param component: Is ignored here
     */
    @Override
    public void show(Frame component) {
        final JFrame jFrame = new JFrame("Bibisect GUI");
        repoFolderOnDiskButton.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                if (SwingUtilities.isLeftMouseButton(e)) {
                    JFileChooser fileChooser = new JFileChooser();
                    fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
                    if (fileChooser.showDialog(jFrame, "Choose folder") == JFileChooser.APPROVE_OPTION) {
                        tbRepoFolderOnDisk.setText(fileChooser.getSelectedFile().getAbsolutePath());
                        updateDropdownList();
                    }

                }
                super.mouseClicked(e);
            }
        });
        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        jFrame.add(mainUIJPanel);
        jFrame.setMinimumSize(new Dimension(750, 200));
        jFrame.pack();
        jFrame.setLocationRelativeTo(null);
        List<Image> images = new LinkedList<>();
        images.add(new ImageIcon(MainUI.class.getResource("16.png")).getImage());
        images.add(new ImageIcon(MainUI.class.getResource("32.png")).getImage());
        images.add(new ImageIcon(MainUI.class.getResource("48.png")).getImage());
        images.add(new ImageIcon(MainUI.class.getResource("128.png")).getImage());
        images.add(new ImageIcon(MainUI.class.getResource("256.png")).getImage());
        jFrame.setIconImages(images);
        jFrame.setVisible(true);
    }

    public void updateDropdownList() {
        //TODO
    }
}
