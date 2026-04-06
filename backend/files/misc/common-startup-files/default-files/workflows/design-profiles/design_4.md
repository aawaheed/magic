# Design System: Editorial / Digital News Magazine

## 1. Visual Theme & Atmosphere
The interface is a **classic-modern hybrid news portal** that mimics the intellectual gravity of a physical broadsheet while utilizing digital efficiency. The design is built on a **pure ivory-white canvas** (`#ffffff`), prioritizing high-contrast legibility and photographic storytelling. The atmosphere is neutral and objective, using a **"Grid of Truth"**—a multi-column layout that organizes diverse global stories into a cohesive, non-hierarchical feed.

The design relies on **strong vertical and horizontal axis lines** to separate categories (Business, Travel, Politics). The visual weight is distributed through a "Hero-Mosaic" approach, where the central featured story acts as a pivot point for smaller, stacked sidebar items. It feels like a high-end publication for a global audience—authoritative, dense, and curated.

**Key Characteristics:**
- **Broadsheet-Style Grid**: Strict multi-column alignment reminiscent of traditional newspaper layouts.
- **Category-First Architecture**: Explicit section headers (Business, Politics) serve as the primary navigational anchors.
- **Center-Weighted Hero**: The most important story occupies the horizontal center with a larger aspect ratio image.
- **Monochromatic Accents**: A singular **Primary Blue** (`#007bff`) for high-intent CTAs like "Subscribe."
- **Data-Rich Sidebar**: A dedicated "Latest" vertical column for high-frequency updates.
- **Understated Meta-data**: Thin font weights for dates and author names to keep the focus on headlines.
- **Fixed-Top Header**: Minimalist navigation bar with search and subscription focus.

## 2. Color Palette & Roles

### Core Neutrals
- **Pure White** (`#ffffff`): `--palette-bg-primary`, the foundational canvas.
- **Ink Black** (`#000000`): `--palette-text-primary`, used for the masthead logo and primary headlines.
- **News Gray** (`#222222`): `--palette-text-body`, for maximum readability in article excerpts.
- **Muted Stone** (`#777777`): `--palette-text-secondary`, used for dates, categories, and author bylines.
- **Border Smoke** (`#eeeeee`): `--palette-border-divider`, ultra-thin lines separating content blocks.

### Primary Accents
- **Action Blue** (`#007bff`): `--palette-bg-accent`, exclusively for the "Subscribe" CTA and active category states.
- **Interactive Blue** (`#0056b3`): Hover states for links and navigation.

## 3. Typography Rules

### Font Family
- **Primary**: `Playfair Display` or `Georgia` (Serif) for headings to signal authority.
- **Secondary**: `Inter` or `Montserrat` (Sans-Serif) for UI, menus, and meta-data.

### Hierarchy

| Role | Font | Size | Weight | Line Height | Letter Spacing | Notes |
|------|------|------|--------|-------------|----------------|-------|
| Logo Masthead | Playfair | 36px | 900 | 1.0 | 0.05em | Bold, centered, authoritative |
| Main Hero Headline | Playfair | 28px | 700 | 1.2 | -0.01em | The central story focus |
| Section Header | Inter | 12px | 700 | 1.0 | 0.08em | `text-transform: uppercase` |
| Card Headline | Playfair | 18px | 700 | 1.3 | normal | Grid-based story titles |
| Body Excerpt | Inter | 14px | 400 | 1.5 | normal | Gray text for easy reading |
| Meta-data (Date) | Inter | 11px | 400 | 1.0 | normal | Muted gray |
| Nav Link | Inter | 13px | 600 | 1.0 | normal | Horizontal menu items |

### Principles
- **Serif/Sans-Serif Contrast**: Headlines are Serif (traditional/storytelling); metadata is Sans-Serif (digital/functional).
- **Tight Verticality**: Minimal spacing between the headline and the meta-line to keep the "story unit" together.
- **Legibility Over Stylization**: Standard weights (400/700) ensure accessibility across all device types.

## 4. Component Stylings

### Buttons
- **Subscribe (Primary)**: Background `#007bff`, White text, 4px radius, 10px 20px padding.
- **Secondary CTAs**: Underlined text links without background containers.

### Article Cards
- **Structure**: Vertical stack — Category Label (Top) → Image → Headline → Meta → Excerpt.
- **Image Treatment**: 3:2 aspect ratio for standard cards; 16:9 for hero cards. No borders or shadows.
- **Divider Lines**: 1px horizontal `#eeeeee` border above section titles.

### Navigation
- **Top Bar**: Minimalist white background, logo centered, utility links (Log-in, Subscribe) right-aligned.
- **Category Bar**: Secondary horizontal scroll or multi-link row below the masthead.

## 5. Layout Principles
- **Modular Mosaic**: Different row configurations (e.g., 1-column hero row followed by a 4-column grid row).
- **Horizontal Flow**: Section titles (e.g., "TRAVEL") are positioned above the content grid, left-aligned with a "View All" link right-aligned.
- **The "Columnist" Sidebar**: A narrower right-hand column (approx. 25% width) for high-density news snippets.

## 6. Depth & Elevation

| Level | Treatment | Use |
|-------|-----------|-----|
| Level 0 | Flat Surface | Entire site background and cards |
| Level 1 | 1px line divider | Content separation only |
| Level 2 | No Elevation | Images and text are "printed" on the surface |

## 7. Do's and Don'ts

### Do
- Use **high-resolution documentary photography**; the images are the color of the site.
- Maintain **strict alignment**; every element should snap to a vertical column line.
- Use **uppercase sans-serif labels** for categories (e.g., POLITICS) to act as visual flags.
- Keep the design **monochromatic**; let the blue "Subscribe" button be the only non-image color.

### Don't
- Don't use rounded corners on images; keep them sharp (0px) to maintain the paper aesthetic.
- Don't use drop shadows; depth is created through whitespace and dividers.
- Don't use vibrant background colors; the canvas must remain white or very light ivory.
- Don't use overly stylized or "fun" fonts; stick to classic, legible families.

## 8. Responsive Behavior
- **Desktop**: 4-column main grid + 1-column sidebar.
- **Tablet**: 2-column grid; sidebar moves to the bottom of the section.
- **Mobile**: Single-column vertical stack; category bar becomes a horizontal scrollable list.

## 9. Agent Prompt Guide

### Quick Color Reference
- Background: `#ffffff`
- Primary Text: `#000000`
- Meta Text: `#777777`
- Accent: `#007bff`

### Example Component Prompts
- "Design a magazine article card: Sharp 3:2 image, 18px Playfair Display Bold headline, 11px Inter uppercase category label in gray above the image."
- "Create a news hero section: Center-aligned masthead 'HAGUE' in 36px Playfair Black. Large 16:9 centered photo with a 28px serif headline below it."
- "Build a section divider: 1px light gray horizontal line, 'BUSINESS' in 12px Inter Extra-Bold Uppercase left-aligned, 'View All' right-aligned in blue."
- "Design a 'Latest' sidebar: Vertical list of text-only items, 14px bold headlines, 11px gray dates, separated by thin dividers."

### Iteration Guide
1. Start with a 12-column grid to ensure all cards align perfectly.
2. Use Serif fonts for headlines to convey trust and history.
3. Reserve the color Blue solely for conversion and navigation.
4. Treat images as the primary visual interest; the UI should be invisible.
5. Focus on vertical rhythm—keep consistent spacing between the headline, meta-data, and body text.

---

### **Upgrade Suggestions & Questions**

1.  **Palette Refinement**: Would you like to introduce a **"Reading Mode"** toggle that switches the background to a soft Sepia (`#f4ecd8`) for better eye comfort?
2.  **Typography Polish**: Should we use **Drop Caps** (large first letters) for the main hero story to enhance the "literary magazine" feel?
3.  **Interaction Design**: How about a **"Reading Progress Bar"** at the top of the header that fills up as the user scrolls through the page?
4.  **Layout Evolution**: Should we implement an **"Infinite Scroll"** for the Latest News sidebar so readers never stop browsing headlines?
5.  **Micro-Interactions**: Would you like to add a **"Bookmark/Save for Later"** icon that appears on hover for every article card?