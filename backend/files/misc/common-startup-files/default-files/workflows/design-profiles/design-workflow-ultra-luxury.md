# Design System: Ultra-Luxury Hospitality & Resort
WORKFLOW ==> design-workflow-ultra-luxury

## 1. Visual Theme & Atmosphere
The interface is a **"Cinematic Sanctuary"**—a high-end editorial layout that prioritizes atmosphere and sensory appeal. Built on a "Warm Obsidian" canvas (#0c0a09), the design uses deep shadows and golden-hour lighting to evoke feelings of exclusivity and calm. The atmosphere is quiet and expensive, utilizing a "Visual-First" strategy where full-width photography does the heavy lifting, supported by minimalist, elegant typography.

**Key Characteristics:**
* **Hero-Immersive Background:** A full-bleed, high-resolution interior photo that sets the mood of the physical space.
* **Gold & Ebony Contrast:** A classic luxury pairing of gold accents on a near-black background to signify wealth and prestige.
* **Grid of Excellence:** A balanced 3-column room showcase that uses identical aspect ratios for a sense of mathematical harmony.
* **Utility Info-Strip:** A semi-transparent bar below the hero for mission-critical logistics (Check-in, Location, Support).

## 2. Color Palette & Roles
### Core Neutrals
* **Warm Obsidian (#0c0a09):** `--palette-bg-primary`, the foundational dark canvas.
* **Soft Champagne (#e5e5e5):** `--palette-text-body`, used for secondary descriptions to avoid the harshness of pure white.
* **Pure Ivory (#ffffff):** `--palette-text-primary`, reserved for high-impact headlines.

### Primary Accents
* **Metallic Gold (#c2a370):** `--palette-bg-accent`, used for "Book Your Stay" CTAs, price tags, and icons.
* **Muted Bronze (#8a7352):** `--palette-bg-hover`, used for button hover states and subtle dividers.

## 3. Typography Rules
### Font Family
* **Primary:** **Cormorant Garamond** or **Playfair Display** (Classic Serif) for headlines to signal legacy and five-star quality.
* **Secondary:** **Montserrat** or **Lato** (Clean Sans-Serif) for UI labels, navigation, and metadata to maintain readability.

### Hierarchy
| Role | Font Size | Weight | Line Height | Letter Spacing | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **Luxury Headline** | 64px | 500 | 1.1 | -0.01em | High-impact Serif |
| **Section Header** | 32px | 600 | 1.3 | 0.02em | Serif, gold or white |
| **Room Title** | 22px | 600 | 1.4 | normal | Clean Sans-Serif |
| **Price Label** | 14px | 700 | 1.0 | 0.05em | Uppercase on Gold background |
| **Body Prose** | 16px | 300 | 1.8 | normal | High line-height for "breathing" |

## 4. Component Stylings
* **Buttons:** Rectangular with a tiny 2px–4px radius. The primary CTA uses a solid Gold background with dark text for maximum "click-ability" against the dark theme.
* **Info-Strip Modules:** Minimalist line-art icons in gold, paired with vertically stacked text (Label above, Detail below).
* **Room Cards:** A vertical stack: 1:1 or 4:3 Image → Title → Description → Gold Price Badge.
* **The "Aspire" Logo:** Centered or left-aligned Serif wordmark with a geometric diamond icon to denote "Five-Star" status.

## 5. Layout Principles
* **Central Pivot:** The hero text is left-aligned to clear the visual space of the image, while the "Discover" section uses an asymmetrical "Text-Left / Dual-Image-Right" layout to create movement.
* **Logical Chunking:** Information is grouped by intent: *Inspiration* (Hero) → *Information* (Strip) → *Selection* (Rooms) → *Deep Dive* (Discover).
* **Negative Space Mastery:** Deep black margins and wide gutters ensure the user never feels overwhelmed.

## 6. Depth & Elevation
| Level | Treatment | Use |
| :--- | :--- | :--- |
| **Level 0** | Deep Black base | Page background |
| **Level 1** | Transparent Overlays | The logistics info-strip and navigation bar |
| **Level 2** | Image "Cut-outs" | Room images and lifestyle gallery |

## 7. Do's and Don'ts
### Do
* Use photography with warm, yellow/orange light tones to match the gold accents.
* Keep buttons wide and flat; avoid heavy drop shadows that look "cheap."
* Use Serif fonts for anything related to "Luxury" or "Experience."
### Don't
* Don't use vibrant primary colors (Blue, Green, Red); they will break the "Resort" mood.
* Don't use rounded pill shapes; luxury is often associated with sharp, architectural lines.
* Don't clutter the navigation; keep links to 4–5 max.

## 8. Responsive Behavior
* **Desktop:** Full-width hero with a 3-column room grid.
* **Tablet:** Room grid shifts to a 2-column layout (the 3rd room drops to a full-width focus card).
* **Mobile:** Single-column vertical stack. The hero image shifts focus to the center of the room. The info-strip becomes a 3-row list of icons.

## 9. Agent Prompt Guide
**Quick Color Reference**
* **Background:** #0c0a09
* **Primary Text:** #ffffff
* **Gold Accent:** #c2a370

**Example Component Prompts**
* "Design a luxury hero: 64px Serif headline 'Experience Five-Star...', a gold rectangular CTA, and a high-end suite photo background."
* "Create a room card: Sharp 4:3 image of a hotel bed, 22px Sans-Serif title, and a gold #c2a370 badge at the bottom with price text."
* "Build an info-bar: Semi-transparent black background, three gold icons with white text labels for Check-in, Location, and Support."

**Iteration Guide**
1.  **Set the Canvas:** Start with the **Warm Obsidian** background. If using imagery, apply a dark overlay (30-40% opacity) to ensure white text pops.
2.  **Typography Balance:** Apply the **Serif headlines** first to establish the high-end tone, then use the clean Sans-Serif for all functional data.
3.  **Color Spotlighting:** Use the **Gold (#c2a370)** strictly for high-conversion zones (Booking buttons) and status indicators (Prices).
4.  **Whitespace Audit:** Increase the padding between the Room Grid and the Discover sections. Luxury designs require "air" to feel premium.
5.  **Image Tone Check:** Ensure all photos are color-graded to have warm highlights. Cool or blue-toned photos will clash with the Gold/Obsidian palette.

---

### Upgrade Suggestions & Questions

1.  **Immersive Video:** Would you like to replace the static Hero image with a **muted, slow-motion video loop** of the waves or the resort lobby?
2.  **Interactive Floorplans:** Should the Room cards include a small **"View Floorplan" toggle** that appears on hover, giving travelers more spatial confidence?
3.  **Booking Micro-interactions:** How about a **date-picker** that slides out from the "Book Your Stay" button rather than taking the user to a new page?
4.  **Mood Toggles:** Would you like a **"Day/Night" toggle** that shifts the site from warm golden tones to a cool, moonlit silver palette for night browsing?
5.  **Dynamic Availability:** Should we add a small **"Only 2 rooms left" pulse** in the Gold accent color to create soft urgency for specific suites?