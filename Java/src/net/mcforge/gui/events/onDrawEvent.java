package net.mcforge.gui.events;

import java.awt.Graphics;

import net.mcforge.API.EventList;
import net.mcforge.gui.window.render.Render;

public class onDrawEvent extends RenderEvent {

	private Graphics g;
	
	private static EventList events = new EventList();
	
	public onDrawEvent(Graphics g, Render render) {
		super(render);
		this.g = g;
		
	}

	@Override
	public EventList getEvents() {
		return events;
	}
	
	public Graphics getGraphics() {
		return g;
	}
	
	public static EventList getEventList() {
		return events;
	}

}
