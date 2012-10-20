package net.mcforge.gui.window;

import javax.swing.JFrame;

import net.mcforge.API.EventHandler;
import net.mcforge.API.Listener;
import net.mcforge.API.io.ServerLogEvent;
import net.mcforge.gui.events.onDrawEvent;
import net.mcforge.gui.launch.Main;
import net.mcforge.server.Server;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class ConsoleView extends Window implements Listener, KeyListener {
	private static final long serialVersionUID = 4407801204193627925L;
	
	private JTextField textField;
	private JTextArea textPane = new JTextArea();
	private JScrollPane logScroll = new JScrollPane(textPane);
	
	public ConsoleView(Server server, String[] logs) {
		super(server);
		for (String s : logs) {
			log(s);
		}
	}
	
	public ConsoleView(Server server) {
		this(server, new String[0]);
	}
	public ConsoleView() {
		super(null);
	}
	
	public JFrame getContentPane() {
		return Main.INSTANCE.frame;
	}

	@Override
	public void tick() {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void init() {
		Main.INSTANCE.frame.setVisible(false);
		Main.INSTANCE.frame.dispose();
		Main.INSTANCE.frame.setResizable(false);
		Main.INSTANCE.frame.setVisible(true);
		
		getContentPane().getContentPane().setLayout(null);
		
		textField = new JTextField();
		textField.setBounds(10, 410, 590, 20);
		textField.addKeyListener(this);
		getContentPane().getContentPane().add(textField);
		textField.setColumns(10);
		
		textPane.setEditable(false);
		//textPane.setBounds(0, 0, 590, 388);
		logScroll.setBounds(10, 11, 590, 388);
		getContentPane().getContentPane().add(logScroll);
		getContentPane().setSize(630, 500);
	}

	@Override
	public String getName() {
		return "MCForge " + Main.INSTANCE.getServer().VERSION;
	}

	@Override
	public int defaultWidth() {
		return 0; //We manually resize it
	}

	@Override
	public int defaultHeight() {
		return 0; //We manually resize it
	}

	@Override
	public void draw(onDrawEvent event) {
	}
	
	@EventHandler
	public void onLog(ServerLogEvent event) {
		log(event.getRawMessage());
	}
	
	@Override
	public void keyPressed(KeyEvent arg0) {
		if (arg0.getKeyCode() == KeyEvent.VK_ENTER && textField.hasFocus()) {
			String text = textField.getText();
			Main.INSTANCE.globalMessage(text);
			textField.setText("");
		}
	}
	@Override
	public void keyReleased(KeyEvent arg0) { }
	@Override
	public void keyTyped(KeyEvent arg0) { }
	
	
	public void log(String message) {
		textPane.setText(textPane.getText() + "\n" + message);
		textPane.setCaretPosition(textPane.getDocument().getLength());
	}
}
