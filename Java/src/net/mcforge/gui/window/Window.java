package net.mcforge.gui.window;

import java.awt.Canvas;

import net.mcforge.API.Listener;
import net.mcforge.gui.events.onDrawEvent;
import net.mcforge.gui.window.render.Render;
import net.mcforge.server.Server;
import net.mcforge.server.Tick;

public abstract class Window extends Canvas implements Tick, Listener {
	private static final long serialVersionUID = -8891174773885679995L;

	private Server system;
	
	private Render render;
	
	public Window(Server system) {
		this.system = system;
		this.system.getEventSystem().registerEvents(this);
		render = new Render(this);
		system.Add(this);
	}
	
	public abstract void init();
	
	public void onLoad() {
		render.start();
	}
	
	public void onUnload() {
		render.finalize();
	}
	
	public abstract String getName();
	
	public abstract void draw(onDrawEvent event);
	
	public Server getSystem() {
		return system;
	}
}
