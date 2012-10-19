package net.mcforge.gui.window.render;

import java.awt.Graphics;
import java.awt.Toolkit;
import java.awt.image.BufferStrategy;

import net.mcforge.gui.events.onDrawEvent;
import net.mcforge.gui.window.Window;
import net.mcforge.server.Tick;


public class Render implements Tick {
	
	private Window currentWindow;
	private BufferStrategy bf;
	private Graphics g = null;

	public Render(Window window) {
		this.currentWindow = window;
	}
	
	public void start() {
		currentWindow.createBufferStrategy(2);
		currentWindow.getSystem().Add(this);
	}
	
	public void finalize() {
		currentWindow.getSystem().Remove(this);
		bf = null;
		g = null;
	}
	
	public void draw() {
		bf = currentWindow.getBufferStrategy();
		g = bf.getDrawGraphics();
		try {
			onDrawEvent event = new onDrawEvent(g, this);
			currentWindow.getSystem().getEventSystem().callEvent(event);
		} finally {
			g.dispose();
		}
		bf.show();
		Toolkit.getDefaultToolkit().sync();
	}

	@Override
	public void tick() {
		draw();
	}
}
