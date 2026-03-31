# Create dashed upload dropzone card with hidden file input
WORKFLOW ==> dashed-upload-dropzone-card-with-hidden-file-input

## Visual identity
A pure HTML and CSS upload card styled as a clean dashed dropzone panel with a centered file icon and helper text. The component looks like a modern white upload area with rounded corners, soft shadow, muted gray border styling, and a hidden native file input triggered by clicking the card.

## Workflow description
Create a pure HTML and CSS file upload card using a label as the visible dropzone and a hidden file input.

### Required structure
1. Use a label element as the main visible upload area.
2. Link the label to a file input using the for attribute and matching id.
3. Place an icon container inside the label.
4. Place a text container inside the label.
5. Add a hidden input of type file inside or alongside the label.
6. Keep the label fully clickable so it triggers the file picker.

### Required styling
1. Style the upload area as a rectangular card around 300px wide and 200px high.
2. Use a white background.
3. Add a dashed light gray border around the full card.
4. Use rounded corners around 10px.
5. Add a soft subtle drop shadow.
6. Use flex layout with vertical stacking.
7. Center the content horizontally and vertically.
8. Add spacing between the icon and text around 20px.
9. Use pointer cursor for the full card.
10. Add internal padding around 1.5rem.

### Required icon behavior
1. Place a centered upload or document style SVG icon near the top half of the card.
2. Size the icon prominently around 80px high.
3. Use a muted gray fill color for the icon.
4. Keep the icon static and clean.

### Required text behavior
1. Place helper text below the icon.
2. Center the text horizontally.
3. Use a normal font weight around 400.
4. Use a muted dark gray text color.
5. Use text similar to Click to upload image.

### Technical implementation notes
1. Do not use JavaScript.
2. Use plain HTML and CSS only.
3. Hide the native file input with display none.
4. Use the label click behavior to open the file selector.
5. Keep the component suitable for image upload or general file upload interfaces.

### Code fingerprint
```html
<label class="custum-file-upload" for="file">
  <div class="icon">
    <svg></svg>
  </div>
  <div class="text">
    <span>Click to upload image</span>
  </div>
  <input type="file" id="file">
</label>
```

```css
.custum-file-upload {
  height: 200px;
  width: 300px;
  display: flex;
  flex-direction: column;
  gap: 20px;
  cursor: pointer;
  align-items: center;
  justify-content: center;
  border: 2px dashed #cacaca;
  background-color: rgba(255, 255, 255, 1);
  border-radius: 10px;
}

.custum-file-upload .icon svg {
  height: 80px;
  fill: rgba(75, 85, 99, 1);
}

.custum-file-upload .text span {
  font-weight: 400;
  color: rgba(75, 85, 99, 1);
}

.custum-file-upload input {
  display: none;
}
```

### Search keywords
upload dropzone card, dashed file upload area, hidden file input label, click to upload card, image upload panel, pure css upload widget, upload box with icon, file picker card ui
