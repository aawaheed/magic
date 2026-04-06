# Design System: Modern Architecture / Luxury Real Estate Landing Page
WORKFLOW ==> design-workflow-modern-architecture

## 1. Visual Theme & Atmosphere
The interface is a **minimalist, high-end architectural showcase** that prioritizes "Structural Elegance" and "Boutique Living." It utilizes an **extreme editorial scale**, where oversized typography intersects with architectural photography to create a sense of monumental space. The atmosphere is quiet, premium, and sophisticated, leaning heavily into the **"Scandi-Noir"** aesthetic—balancing cold, dark exteriors with warm, glowing interiors.

The design relies on a **layered typographic depth** system where the brand name or main headline acts as a background element for physical structures, creating a 3D relationship between the text and the building. It avoids traditional UI clutter, favoring a "Gallery" approach where the architecture is the interface.

**Key Characteristics:**
* **Typography as Architecture**: Massive headers (e.g., "Hotle") that dwarf the primary navigation.
* **High-Contrast Warmth**: Deep blacks and charcoal grays contrasted against the amber glow of interior lighting.
* **Minimalist Utility**: Ultra-thin borders and pill-shaped buttons that stay out of the way of the imagery.
* **Asymmetrical Balance**: Text-heavy sections are balanced by expansive, full-bleed photography.
* **Monochromatic Text System**: Strictly black and white typography to maintain a professional, timeless feel.
* **Luxury Editorial Flow**: Transitions from high-impact "Hero" visuals to clean, informative "Data" blocks (Stats/Explanations).

## 2. Color Palette & Roles

### Core Neutrals
* **Canvas Gray** (`#f3f3f3`): `--palette-bg-base`, a soft, gallery-style off-white that reduces eye strain compared to pure white.
* **Obsidian Black** (`#000000`): `--palette-text-primary`, used for massive headers and high-contrast titles.
* **Graphite** (`#1a1a1a`): `--palette-bg-structure`, used for building facades and primary UI elements like the "Home" tag.
* **Muted Slate** (`#666666`): `--palette-text-secondary`, for small metadata, labels, and descriptions.

### Accent & Glow
* **Amber Interior** (`#ffbf00`): Found within the photography; used to guide the eye toward "Living Spaces."
* **Soft Border** (`rgba(0,0,0,0.1)`): Used for thin dividers and pill-shaped button outlines.

## 3. Typography Rules

### Font Family
* **Primary (Headers)**: `Inter` or `Plus Jakarta Sans` (Geometric Sans-Serif) for a modern, industrial feel.
* **Secondary (Editorial)**: `Playfair Display` or `Instrument Serif` (Elegant Serif) for "Stunning architecture..." subtitles.

### Hierarchy

| Role | Font | Size | Weight | Line Height | Letter Spacing | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| **Brand Masthead** | Inter | 180px+ | 800 | 0.8 | -0.05em | Partially hidden by images |
| **Editorial Quote** | Instrument Serif | 48px | 400 | 1.1 | normal | Italicized for "lifestyle" feel |
| **Section Title** | Inter | 42px | 700 | 1.2 | -0.02em | "Comfort x Nature" |
| **Stats Number** | Inter | 36px | 600 | 1.0 | normal | High-impact data |
| **Nav/UI Pill** | Inter | 12px | 500 | 1.0 | 0.02em | Small, precise labels |
| **Body Copy** | Inter | 14px | 400 | 1.6 | normal | Light gray readability |

### Principles
* **Size Contrast**: The difference between the 180px masthead and the 12px nav labels creates an "Architectural" scale (Big vs. Small).
* **Serif Infusion**: Using an elegant serif for descriptive copy adds a "Boutique" human touch to the cold geometric layout.
* **Negative Tracking**: Tight letter-spacing on large headers to make them feel like a solid structural block.

## 4. Component Stylings

### Navigation & Pills
* **Active Tab**: Black pill with white text, 20px radius.
* **Inactive Tab**: Transparent with 1px light border or no border.
* **Join Waitlist**: Outline-style button, thin 1px border, 20px radius.

### Statistics Block
* **Style**: Large bold numbers with muted gray labels directly beneath.
* **Divider**: 1px vertical hair-line (`#e0e0e0`) between data points to mimic blueprint lines.

### Search / Input
* **Style**: Extremely minimal. Pill-shaped container with a "Search my area" placeholder and a small arrow icon.

## 5. Layout Principles
* **The "Overlap" Technique**: Images should physically overlap background text to create layers of depth.
* **Horizontal Breathers**: Use 120px+ vertical margins to separate the "Visual Hero" from the "Text Information" sections.
* **Golden Ratio Grids**: Text blocks (like the "Stunning architecture" section) occupy 60% of the width, leaving 40% as white space.

## 6. Depth & Elevation

| Level | Treatment | Use |
| :--- | :--- | :--- |
| **Level 0** | Flat Background | Canvas Gray base |
| **Level 1** | Text Layer | The "Hotle" masthead background |
| **Level 2** | Image Layer | Buildings and modular cabin cutouts |
| **Level 3** | UI Layer | Navigation pills and floating buttons |

## 7. Do's and Don'ts

### Do
* Use **high-end photography** featuring straight lines and dramatic lighting.
* Keep the **border-radius small** (pills) or **sharp** (images).
* Maintain a **strictly monochromatic** color scheme for the UI; let the photos provide the color.
* Ensure the **typographic scale** is exaggerated (massive vs. tiny).

### Don't
* Don't use drop shadows; depth is achieved via layering and overlapping, not shadows.
* Don't use vibrant colors for buttons; use Black or Outline White.
* Don't clutter the hero section with more than 3-4 navigation items.
* Don't use "loud" icons; keep them thin-line and minimal.

## 8. Responsive Behavior
* **Desktop**: Full "Overlap" layout with massive typography.
* **Tablet**: Typography scales down to 80px; image overlap is reduced.
* **Mobile**: Single-column stack. The massive background text is removed or significantly reduced to ensure the image remains the focus.

## 9. Agent Prompt Guide

### Quick Color Reference
* Background: `#f3f3f3`
* Header Black: `#000000`
* Secondary Text: `#666666`
* Accent Interior: `#ffbf00` (within photos)

### Example Component Prompts
* "Create a minimalist architectural hero: Off-white background, massive 180px 'ARCH' text in black, with a high-res modern house image overlapping the bottom half of the text."
* "Design an editorial stat row: 3 columns separated by 1px gray vertical lines. Numbers in 36px Inter Bold, labels in 12px Inter Medium Gray."
* "Build a navigation bar: Centered black pill for 'Home', text-only 'Backyard' and 'Works', right-aligned 'Join Waitlist' outline button."
* "Design an architectural section title: 'Comfort x Nature' in 42px Inter Bold, centered, with 80px of vertical padding on top and bottom."

### Iteration Guide
1.  Start with the massive background text to establish the scale.
2.  Layer the primary architectural image over the text.
3.  Add the thin-line navigation and pill buttons to the top layer.
4.  Transition into a clean, serif-based editorial section for storytelling.
5.  End with a grid-based statistics block for professional proof.

---

### **Upgrade Suggestions & Questions**

1.  **Motion Design**: Would you like to add a **"Slow Zoom"** effect on the hero image so it appears to be growing within the frame as the user lands?
2.  **Interactive Depth**: Should we implement a **"Horizontal Scroll"** for the modular cabin section to showcase different architectural models?
3.  **Color Polish**: How about adding a **"Dark Mode"** switch where the background flips to Slate (`#1a1a1a`) and the text to Off-White?
4.  **Typography Swap**: Should the numbers in the statistics section use a **"Slab Serif"** font to give them more weight and "blueprint" character?
5.  **Micro-Interactions**: Would you like the "Search my area" pill to **expand into a full-screen search** overlay when clicked?