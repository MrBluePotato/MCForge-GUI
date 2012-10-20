package net.mcforge.gui.window;

import java.awt.Cursor;
import java.awt.Font;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Random;

import javax.imageio.ImageIO;

import net.mcforge.API.EventHandler;
import net.mcforge.API.Listener;
import net.mcforge.API.io.ServerLogEvent;
import net.mcforge.API.plugin.CommandLoadEvent;
import net.mcforge.API.plugin.PluginLoadEvent;
import net.mcforge.API.server.ServerStartedEvent;
import net.mcforge.gui.events.onDrawEvent;
import net.mcforge.gui.launch.Main;
import net.mcforge.server.Server;

public class SplashScreen extends Window implements Listener {
	private static final long serialVersionUID = -6755920067876325151L;
	
	private boolean drawed = false;
	private BufferedImage splash;
	private String currentString;
	private static final Random rand = new Random();
	private ArrayList<String> logs = new ArrayList<String>();
	public SplashScreen(Server system) {
		super(system);
		// TODO Auto-generated constructor stub
	}

	@Override
	public void tick() {
	}
	
	public void setText(String text) {
		this.currentString = text;
	}
	
	public String getText() {
		return currentString;
	}

	@Override
	public void init() {
		Main.INSTANCE.frame.setVisible(false);
		Main.INSTANCE.frame.dispose();
		Main.INSTANCE.frame.setResizable(false);
		Main.INSTANCE.frame.setUndecorated(true);
		Main.INSTANCE.frame.setLocationRelativeTo(null);
		Main.INSTANCE.frame.setVisible(true);
		Cursor mouse = new Cursor(Cursor.WAIT_CURSOR);
		this.setCursor(mouse);
		try {
			splash = ImageIO.read(new File("splash.png"));
		} catch (IOException e) {
			e.printStackTrace();
		}
		currentString = "Starting..";
	}

	@Override
	public String getName() {
		return "Splash";
	}

	@Override
	@EventHandler
	public void draw(onDrawEvent event) {
		if  (splash == null)
			return;
		event.getGraphics().drawImage(splash, 0, 0, splash.getWidth(), splash.getHeight(), null);
		if (!currentString.equals("")) {
			Font font = new Font("Arial", Font.BOLD, 20);
			event.getGraphics().setFont(font);
			event.getGraphics().drawString(currentString, (splash.getWidth() / 2) - (currentString.length() * 6), 300);
		}
		if (!drawed) {
			drawed = true;
			new Start().start();
		}
	}
	
	@EventHandler
	public void onPluginLoad(PluginLoadEvent event) {
		setText("Loaded: " + event.getPlugin().getName());
	}
	
	@EventHandler
	public void onLog(ServerLogEvent event) {
		if (event.getMessage().indexOf("Server url") != -1) {
			setText("Please wait..");
		}
		else
			setText(event.getMessage());
		logs.add(event.getRawMessage());
	}
	
	@EventHandler
	public void onCommandLoad(CommandLoadEvent event) {
		setText("Loaded: " + event.getCommand().getName());
	}
	
	@EventHandler
	public void onDone(ServerStartedEvent event) {
		try {
			Thread.sleep(3000);
		} catch (InterruptedException e) { }
		PluginLoadEvent.getEventList().unregister(this);
		ServerLogEvent.getEventList().unregister(this);
		CommandLoadEvent.getEventList().unregister(this);
		ServerStartedEvent.getEventList().unregister(this);
		Main.INSTANCE.showConsole(logs.toArray(new String[logs.size()]));
	}

	@Override
	public int defaultWidth() {
		return 611;
	}

	@Override
	public int defaultHeight() {
		return 352;
	}

	private class Start extends Thread {

		@Override
		public void run() {
			currentString = "Setting up the server..";
			try {
				Thread.sleep(rand.nextInt(300));
			} catch (InterruptedException e) { }
			new StartServer().start();	
		}
	}

	private class StartServer extends Thread {

		@Override
		public void run() {
			Main.INSTANCE.start();
		}
	}

}
