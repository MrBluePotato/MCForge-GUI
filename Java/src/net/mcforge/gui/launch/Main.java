package net.mcforge.gui.launch;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.GraphicsDevice;
import java.awt.GraphicsEnvironment;
import java.io.IOException;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

import net.mcforge.chat.ChatColor;
import net.mcforge.chat.Messages;
import net.mcforge.groups.Group;
import net.mcforge.gui.window.ConsoleView;
import net.mcforge.gui.window.SplashScreen;
import net.mcforge.gui.window.Window;
import net.mcforge.server.Server;
import net.mcforge.system.Console;

public class Main extends Console {
	public static final Main INSTANCE = new Main();

	private static Group group;
	private Window main;
	private String lastMessage;
	public JFrame frame = new JFrame("Loading...");
	private Server server;
	private Messages chat;

	public static void main(String[] args) {
		INSTANCE.load();
	}

	private void load() {
		server = new Server("[MCForge] Default", 25565, "Welcome!");
		server.Running = true;
		server.startEvents();
		server.startLogger();
		server.startTicker();
		SplashScreen ss = new SplashScreen(server);
		this.setMainWindow(ss);
	}

	public void start() {
		server.Running = false;
		server.Start(this, true);
		chat = new Messages(server);
	}

	public void globalMessage(String message) {
		chat.serverBroadcast(ChatColor.Purple + "[Server] " + ChatColor.White + message);
		sendMessage("[Server] " + message);
	}

	public void stop() throws InterruptedException, IOException {
		if (server.Running)
			server.Stop();
	}

	public void showConsole(String[] logs) {
		ConsoleView c = new ConsoleView(server, logs);
		this.setMainWindow(c);
	}

	@Override
	public Group getGroup() {
		if (group == null) {
			for (Group g : Group.getGroupList()) {
				if (g.isOP) //Dont break, we want the highest rank
					group = g;
			}
		}
		return group;
	}

	@Override
	public String getName() {
		return "Console";
	}

	@Override
	public void sendMessage(String arg0) {
		server.Log(arg0);
		lastMessage = arg0;
	}

	@Override
	public String next() {
		String str = JOptionPane.showInputDialog(null, lastMessage, "", 1);
		return str == null ? "" : str;
	}

	/**
	 * @return the main window
	 */
	public Window getMainWindow() {
		return main;
	}

	public void setFrame(JFrame frame) {
		if (frame != null) {
			frame.setVisible(false);
			frame.dispose();
			frame = null;
		}
		this.frame = frame;
		this.frame.setVisible(true);
	}

	/**
	 * @param main the main window to set
	 */
	public void setMainWindow(Window main) {
		if (frame != null) {
			frame.setVisible(false);
			frame.dispose();
			frame = null;
		}
		if (frame == null) {
			frame = new JFrame("Loading...");
		}
		this.main = main;
		GraphicsDevice gd = GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice();
		frame.setMinimumSize(new Dimension(main.defaultWidth(), main.defaultHeight()));
		frame.setLocation((gd.getDisplayMode().getWidth() - frame.getWidth()) / 2, (gd.getDisplayMode().getHeight() - frame.getHeight()) / 2);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setLayout(new BorderLayout());
		frame.add(main);
		frame.setTitle(main.getName());
		this.main.setFocusable(true);
		frame.pack();
		frame.setVisible(true);
		main.onLoad();
	}
}
