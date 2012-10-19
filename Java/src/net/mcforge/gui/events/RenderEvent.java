package net.mcforge.gui.events;

import net.mcforge.API.Event;
import net.mcforge.gui.window.render.Render;



public abstract class RenderEvent extends Event {
	private Render render;
	
	public RenderEvent(Render render) {
		this.render = render;
	}
	
	public Render getRender() {
		return render;
	}
}
