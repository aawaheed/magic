# Create glossy 3D CSS toggle switch with hidden checkbox and sliding knob
WORKFLOW ==> glossy-3d-toggle-switch-workflow

## Visual identity
A pure HTML and CSS on off toggle made from a hidden checkbox and a label track, with a glossy white pill shaped background, a metallic circular knob, a checked state that slides the knob to the right and darkens it, and a subtle 3D hover tilt that reverses when checked.

## Workflow description
Create a custom toggle switch using only HTML and CSS.

### Required structure
1. Use a hidden `<input type="checkbox">`.
2. Place a `<label>` immediately after the checkbox.
3. Use the label as the visible switch track.
4. Use the label `:before` pseudo-element as the slider knob.

### Required styling
1. The track should be a glossy white pill shape around **120px by 60px** with **30px border radius**.
2. The track should use inset highlights, inset dark shading, and a soft outer shadow to create depth.
3. The knob should be a circular element around **40px by 40px**.
4. In the default state, the knob should sit near the **left side** at about **10px**.
5. The knob should use a metallic or glossy light gradient and soft shadow.
6. In the checked state, the knob should move to about **70px from the left**.
7. In the checked state, the knob should change to a dark gradient or dark glossy appearance.
8. Add smooth transitions around **0.4s**.

### Required interaction
1. On hover, tilt the track slightly using **perspective rotateX and rotateY**.
2. When checked, reverse the hover tilt direction.
3. Do not use JavaScript.

### Code fingerprint
```html
<input type="checkbox" id="checkbox" />
<label for="checkbox" class="label"></label>
```

```css
#checkbox {
  display: none;
}

.label:before {
  content: "";
  left: 10px;
}

#checkbox:checked ~ .label:before {
  left: 70px;
}

.label:hover {
  transform: perspective(100px) rotateX(5deg) rotateY(-5deg);
}

#checkbox:checked ~ .label:hover {
  transform: perspective(100px) rotateX(-5deg) rotateY(5deg);
}
```

### Search keywords
glossy css toggle switch, hidden checkbox label toggle, pill switch, metallic knob, pseudo element slider, checked sibling selector, 3D hover tilt switch, pure CSS on off switch
