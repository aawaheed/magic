# Design System: Educational Platform / University Landing Page

## 1. Visual Theme & Atmosphere
The interface is an **aspirational learning ecosystem** that balances academic tradition with digital innovation. The design operates on a **"Lush Growth"** aesthetic, dominated by a deep **Academic Forest Green** (`#064e3b`) and complemented by high-energy **Teal** (`#2dd4bf`) accents. The atmosphere is encouraging and structured, using organic "scribble" icons and wave-line dividers to add a human, collegiate touch to a high-tech platform.

The design relies on a **Split-Hero Composition**, where text-heavy value propositions are balanced by high-energy student photography with organic masking. It utilizes a **Bento-Style "About" Section**—a grid of varied-size images and stats—to tell a non-linear brand story that feels both modern and authoritative.

**Key Characteristics:**
* **Split-Hero Composition**: Strategic balance between bold text and organically masked student imagery.
* **Academic Trust Anchors**: Use of prestigious serifs for titles paired with functional sans-serifs for UI.
* **Organic Graphic Flourishes**: Hand-drawn style squiggles and circular badges that mimic active learning.
* **Service Grid Icons**: Minimalist line-art on soft-tinted backgrounds for core facilities like libraries and scholarships.
* **Stacked Course Modules**: Clean, card-based navigation featuring clear pricing and quality metadata.
* **Bento-Style Architecture**: A modular grid for storytelling and statistical proof.

## 2. Color Palette & Roles

### Core Neutrals
* **Pure White** (`#ffffff`): `--palette-bg-base`, the primary content surface for course grids and sections.
* **Sage Tint** (`#f0fdf4`): `--palette-bg-secondary`, secondary backgrounds to provide soft visual breaks.
* **Academic Forest** (`#064e3b`): `--palette-text-primary`, used for primary headings and structural anchors.
* **Neutral Gray** (`#6b7280`): `--palette-text-secondary`, for metadata, breadcrumbs, and descriptions.

### Primary Accents
* **Growth Teal** (`#2dd4bf`): `--palette-bg-accent`, exclusively for "Get Started" buttons and active states.
* **Success Gold** (`#facc15`): `--palette-icon-accent`, strictly for course ratings to denote quality.

## 3. Typography Rules

### Font Family
* **Primary**: `Plus Jakarta Sans` or `Montserrat` (Geometric Sans) for headers to signal innovation.
* **Secondary**: `Inter` or `Open Sans` (Sans-Serif) for high-readability body copy and data.

### Hierarchy

| Role | Font | Size | Weight | Line Height | Letter Spacing | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| **Hero Title** | Plus Jakarta | 48px | 800 | 1.1 | -0.02em | Massive impact titles |
| **Section Header** | Plus Jakarta | 32px | 700 | 1.2 | -0.01em | Standard page breaks |
| **Course Title** | Plus Jakarta | 18px | 600 | 1.3 | normal | Card-based headers |
| **Body Copy** | Inter | 14px | 400 | 1.6 | normal | High readability |
| **Price/Stats** | Inter | 16px | 700 | 1.0 | normal | High-contrast data |
| **Pill Tag** | Inter | 11px | 700 | 1.0 | 0.05em | Uppercase bold |

### Principles
* **Scale Contrast**: Significant jumps in size between headers and body text to create energy.
* **Prestigious Weighting**: Heavy weights (700-800) for headers to convey institutional stability.
* **Functional Clarity**: Standard weights for data points ensure accessibility across devices.

## 4. Component Stylings

### Buttons
* **Primary Action (Teal)**: Background `#2dd4bf`, Black text, 24px pill radius, subtle hover glow.
* **Secondary Ghost**: Transparent background, 1px `#064e3b` border, dark green text.

### Academic Cards
* **Course Modules**: Vertical stack — Image (8px radius) → Category Pill → Title → Rating/Price.
* **Service Icons**: Small `#f0fdf4` circles containing 1pt teal line-art icons.
* **Stat Cards**: Floating white boxes with bold numbers and a "plus" symbol (e.g., `130+`).

### Navigation
* **Top Bar**: Minimalist white background, logo left-aligned, utility links right-aligned.
* **Category Strip**: Horizontal row of soft-tinted pills for filtering courses.

## 5. Layout Principles
* **Split-Hero Logic**: Use of asymmetrical layouts to balance text information with student-centric imagery.
* **Bento Storytelling**: A 5-8 unit grid for "About" sections to showcase different institutional strengths.
* **Information Scannability**: Use of wave-line dividers and icons to break up dense academic descriptions.

## 6. Depth & Elevation

| Level | Treatment | Use |
| :--- | :--- | :--- |
| **Level 0** | Flat Surface | Pure White or Sage base layers |
| **Level 1** | Soft Tint Box | Icon backgrounds and category pills |
| **Level 2** | Micro-Shadow | Floating stat boxes and active course cards |

## 7. Do's and Don'ts

### Do
* Use **candid photography** of students in collaborative, well-lit environments.
* Apply **organic masks** (circles/waves) to hero images to feel modern and accessible.
* Use **Growth Teal** for all conversion points to maintain high energy.
* Include **hand-drawn style scribbles** as decorative elements to humanize the tech.

### Don't
* Don't use overly corporate or staged "stock" imagery.
* Don't use aggressive, dark drop shadows; keep depth light and clean.
* Don't use sharp 0px corners on buttons; keep them pill-shaped (24px+).
* Don't use more than two primary accent colors to avoid visual clutter.

## 8. Responsive Behavior
* **Desktop**: Full Split-Hero layout with a multi-column Bento grid.
* **Tablet**: 2-column grid for courses; Hero imagery moves below the headline.
* **Mobile**: Single-column vertical stack; category pills become a horizontal scroll list.

## 9. Agent Prompt Guide

### Quick Color Reference
* Background: `#ffffff`
* Primary Accent: `#2dd4bf`
* Academic Green: `#064e3b`
* Rating Gold: `#facc15`

### Example Component Prompts
* "Design an educational hero: 48px Plus Jakarta Bold title in `#064e3b`, Growth Teal pill button, and a student photo with a wavy mask."
* "Create a course card: 8px radius image, 18px bold header, Success Gold star rating, and '$60' price in teal."
* "Build a Bento stat card: White background, `#064e3b` bold number '130+', and 'Experts' subtitle in gray."
* "Design a service icon: `#f0fdf4` circle with a 1pt Teal line icon for 'Scholarship Facility'."

### Iteration Guide
1. Start with an **Academic Forest Green** foundation for headers to establish trust.
2. Layer in **Growth Teal** for all high-intent buttons and active states.
3. Use **Organic Masks** on photography to soften the academic environment.
4. Maintain **Tight Vertical Rhythm** in cards, grouping titles and ratings closely.
5. Ensure **High Contrast** for prices and stats to aid decision-making.

---

### **Upgrade Suggestions & Questions**

1. **Gamification Polish**: Would you like to add a **"Progress Ring"** to course cards for enrolled students to increase engagement?
2. **Dynamic Navigation**: Should we implement a **"Sticky Enrollment Bar"** that appears once the user scrolls past the hero section?
3. **Typography Variant**: Would you like to introduce a **Serif font** (e.g., "Libre Baskerville") for long-form blog excerpts to enhance academic prestige?
4. **Interactive Stats**: Should the **Bento stat numbers** animate (count up) when they scroll into the user's viewport?
5. **Dark Mode Variant**: How about a **"Night Study" mode** where the canvas flips to Academic Forest (`#064e3b`) and the text to White?