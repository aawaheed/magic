# Design System: Creative Professional / Interactive Resume & Portfolio
WORKFLOW ==> design-workflow-creative-professional

## 1. Visual Theme & Atmosphere
This design is a **bold, high-impact personal brand ecosystem** that merges the grit of street-style aesthetics with professional creative authority. The interface operates on a **Deep Onyx** (`#1a1a1a`) foundation, using large-scale, low-opacity typography in the background to create a "layered" or "3D environment" feel. The atmosphere is confident, disruptive, and highly curated, moving away from traditional resume structures into an **interactive dossier** format.

The visual language uses **Acid Green** (`#98ff00`) and **Neon Lime** as primary energy conductors against the dark background. It features **Glassmorphism** for content containers—translucent cards with soft blurs that make the professional data feel like it’s floating over the artist's persona. It’s a design intended to showcase "Creative DNA" rather than just a list of jobs.

**Key Characteristics:**
- **Maximalist Typography**: Ultra-large background headers (e.g., name and title) act as texture.
- **Glassmorphic Content Blocks**: Translucent containers with 1px border rings for structural clarity.
- **Neon Glow Accents**: Targeted use of Acid Green for stats, skill categories, and directional cues.
- **Circular Type Paths**: "Art Director" badges set on a 360° circular path to add dynamic movement.
- **Logo Wall Integration**: Grayscale "Mega Client" grid to signify professional scale without clashing colors.
- **Hand-drawn Elements**: Subtle "squiggles" or neon arrows to humanize the digital interface.
- **Asymmetrical Balance**: Content is distributed in varying card sizes to create a rhythmic, non-linear reading flow.

## 2. Color Palette & Roles

### Core Brand
- **Onyx Night** (`#1a1a1a`): `--palette-bg-base`, the primary dark canvas.
- **Acid Green** (`#98ff00`): `--palette-accent-neon`, highlights for years of experience, active links, and status markers.
- **Pure White** (`#ffffff`): `--palette-text-primary`, used for high-readability body copy and job titles.
- **Translucent Obsidian** (`rgba(255,255,255,0.05)`): `--palette-bg-glass`, the base for content containers.

### Secondary Tones
- **Low-Opacity Gray** (`rgba(255,255,255,0.15)`): Used for large background watermark text.
- **Muted Silver** (`#a1a1a1`): Secondary text for dates, locations, and descriptions.
- **Portfolio Black** (`#000000`): Deepest contrast for internal card elements and logo backgrounds.

## 3. Typography Rules

### Font Family
- **Primary**: `Bebas Neue` or `Anton` (Impactful Condensed Sans) for massive headers.
- **Secondary**: `Montserrat` or `Inter` (Geometric Sans) for readability in cards.

### Hierarchy

| Role | Font | Size | Weight | Line Height | Letter Spacing | Notes |
|------|------|------|--------|-------------|----------------|-------|
| Background Name | Bebas Neue | 120px+ | 700 | 0.9 | 0.05em | 10% opacity watermark |
| Card Heading | Montserrat | 22px | 800 | 1.1 | 0.02em | `text-transform: uppercase` |
| Job Title | Montserrat | 16px | 700 | 1.2 | normal | High-contrast white |
| Stats/Numbers | Montserrat | 24px | 800 | 1.0 | normal | Acid Green color |
| Body Text | Inter | 14px | 400 | 1.5 | normal | Muted gray color |
| Skill Labels | Inter | 12px | 500 | 1.3 | 0.03em | Right-aligned metadata |

### Principles
- **Extreme Scale Contrast**: The jump from 120px background text to 14px body text creates a sense of immense digital space.
- **Color Coding**: Critical "wins" (250+ Clients) are always Neon to ensure they are the first things the eye sees.
- **Tight Leading**: Headline line-height is kept under 1.1 to maintain a dense, modern "poster" feel.

## 4. Component Stylings

### Containers (The "Dossier" Cards)
- **Background**: `rgba(255,255,255,0.05)` with `backdrop-filter: blur(12px)`.
- **Border**: 1px solid `rgba(255,255,255,0.1)`.
- **Radius**: 16px to 24px for a soft-tech feel.
- **Padding**: Generous 32px internal spacing.

### Portfolio / Behance Link
- **Background**: Solid `#000000` or Deepest Gray.
- **Feature**: Prominent brand icon (Behance logo) with a neon directional arrow.
- **Call to Action**: High-contrast white text "Click my world."

### Logo Grid (Clients)
- **Treatment**: All logos converted to white/grayscale at 40% opacity.
- **Hover**: 100% opacity or subtle neon glow on hover.
- **Spacing**: Tight 8px gutter grid.

## 5. Layout Principles
- **Layered Z-Axis**: The user's portrait sits between the background watermark and the foreground content cards.
- **Vertical Timeline**: The "Creative Journey" uses a left-aligned vertical line with dot markers.
- **The "DNA" Block**: A dedicated high-priority card on the left for quick-glance stats (Stats, Bio).
- **Whitespace (Dark-space)**: Intentional "dead zones" around the central portrait to draw focus to the subject.

## 6. Depth & Elevation

| Level | Treatment | Use |
|-------|-----------|-----|
| Level 0 | Background Text | Low-opacity "MOHAMED RADY" watermark |
| Level 1 | Subject Portrait | Central person cutout (cut at waist/thigh) |
| Level 2 | Content Cards | Glassmorphic cards with subtle inner-glow |
| Level 3 | Neon Accents | Arrows, icons, and stats that appear to "glow" on top |

## 7. Do's and Don'ts

### Do
- Use **high-contrast neon** (`#98ff00`) only for the most important data.
- Maintain **transparency** in cards to keep the "layered" aesthetic.
- Use **condensed bold fonts** for a high-fashion/advertising feel.
- Ensure the grayscale client logos are uniform in size to maintain a "grid" look.
- Use **waist-up cutouts** for the main subject to create a professional but approachable vibe.

### Don't
- Don't use standard drop shadows; use **inner-border glows** or glass blurs.
- Don't use more than one neon accent color; keep it strictly monochromatic + one neon.
- Don't use sharp 0px corners; the design requires a "soft" 16px+ radius for modernism.
- Don't center-align the body text; stick to left or right alignment for a structured look.

## 8. Responsive Behavior
- **Desktop**: Full multi-column dossier layout with portrait centered.
- **Tablet**: Content cards stack vertically; portrait becomes a smaller circular element at the top.
- **Mobile**: Single-column vertical scroll. The large background watermark is removed to prevent clutter.

## 9. Agent Prompt Guide

### Quick Color Reference
- Background: `#1a1a1a`
- Neon Highlight: `#98ff00`
- Glass Card: `rgba(255,255,255,0.05)`
- Secondary Text: `#a1a1a1`

### Example Component Prompts
- "Design a Glassmorphic resume card: 10px blur background, 1px white border at 10% opacity, 20px radius. Headline in Montserrat Extra Bold, Body text in Inter Light."
- "Create a Neon Stat block: '12+' in 32px Montserrat Bold Acid Green (`#98ff00`), 'Years Exp.' in 14px white below it."
- "Build a circular text badge: 'SENIOR ART DIRECTOR' repeating on a circular path, white text, 1px thin weight, centered around a profile icon."
- "Design a dark-mode logo grid: 4 columns, all logos white on a transparent background, 30% opacity, sharp grid layout."

### Iteration Guide
1. Start with the Onyx background and the massive low-opacity watermark.
2. Place the subject portrait as the central anchor.
3. Layer the Glassmorphic cards on top, using asymmetrical heights to create visual interest.
4. Add the Neon Green accents to guide the recruiter's eye to the "Stats" and "Portfolio."
5. Use vertical lines for the timeline to maintain a structured "Creative Journey."

---

### **Upgrade Suggestions & Questions**

1.  **Motion Texture**: Would you like to add a **film grain or noise overlay** to the background to give it a more "tactile, artistic" finish?
2.  **Typography Depth**: How about using a **Stroked/Outlined** version of the background font instead of a solid color to make it even more subtle?
3.  **Color Shift**: Should we introduce a **Gradient Neon** (e.g., Acid Green to Electric Cyan) for the directional arrows to add a "cyber" creative edge?
4.  **Interactive Portfolio**: Would you like to add **mini-thumbnails** that appear in a tooltip when the user hovers over the "Mega Clients" logos?
5.  **Micro-Interactions**: Should the **circular text badge** rotate slowly on a loop to add a layer of sophisticated motion to the page?