# Design System: High-End Audio / E-Commerce Landing Page
WORKFLOW ==> design-workflow-high-end-audio

## 1. Visual Theme & Atmosphere
The interface is a **technical-luxe marketplace** that balances the "cold" precision of high-end audio engineering with the "warmth" of lifestyle photography. The design operates on a dual-canvas system: an immersive, near-black (`#111111`) hero environment that transitions into a clinical, pure-white (`#ffffff`) product grid. The result is a high-contrast experience where products feel like "specimens" of engineering excellence.

The typography is grounded in **geometric sans-serifs**, creating a "tech-forward" voice. Unlike the soft, rounded terminals of lifestyle brands, this system uses sharp, precise glyphs. The interface feels tactile through the use of **isolated product photography** on neutral gray surfaces (`#f6f6f6`), making the hardware the undisputed hero.

**Key Characteristics:**
- High-contrast "Onyx and Alabaster" palette for visual pacing
- Geometric typography (Inter/Satoshi) for a precision-engineered feel
- Product-first "Specimen" cards — hardware is isolated on neutral backdrops
- Single-accent system using **Signal Red** (`#e21b1b`) for urgency and status
- Sharp border-radius (4px–8px) for buttons; circular (50%) for status dots
- High-fidelity product carousels with minimal, technical pagination
- Integrated lifestyle photography to provide human context to the hardware
- Precision spacing (8px base) with generous vertical margins (80px+)

## 2. Color Palette & Roles

### Core Neutrals
- **Onyx Black** (`#111111`): `--palette-bg-primary-dark`, hero backgrounds, primary CTAs
- **Studio White** (`#ffffff`): `--palette-bg-primary-light`, grid surfaces, text on dark
- **Gallery Gray** (`#f6f6f6`): `--palette-bg-secondary-light`, product card backgrounds
- **Stroke Gray** (`#e0e0e0`): `--palette-border-standard`, input outlines, dividers

### Accents & Status
- **Signal Red** (`#e21b1b`): `--palette-accent-primary`, Sale badges, live status indicators
- **Deep Slate** (`#333333`): `--palette-bg-tertiary-dark`, secondary buttons on dark
- **Muted Smoke** (`#767676`): `--palette-text-secondary`, meta-data, descriptions

### Text Scale
- **Absolute Black** (`#000000`): `--palette-text-primary`, used for high-impact headings on white
- **Inverse White** (`#ffffff`): `--palette-text-on-dark`, hero headings and footer content
- **Secondary Gray** (`#666666`): Secondary text, prices, and technical specs

## 3. Typography Rules

### Font Family
- **Primary**: `Inter` (Variable), fallbacks: `Satoshi, -apple-system, system-ui, Roboto`
- **Style**: Geometric, high x-height, clean legibility for technical data

### Hierarchy

| Role | Font | Size | Weight | Line Height | Letter Spacing | Notes |
|------|------|------|--------|-------------|----------------|-------|
| Hero Heading | Inter | 48px | 700 | 1.1 | -0.02em | High-impact headlines |
| Section Title | Inter | 32px | 700 | 1.2 | -0.01em | Standard page breaks |
| Product Title | Inter | 18px | 600 | 1.3 | normal | Bold product names |
| UI/Nav Medium | Inter | 14px | 500 | 1.0 | 0.01em | Navigation items |
| Body Copy | Inter | 14px | 400 | 1.6 | normal | Descriptive text |
| Price/Meta | Inter | 15px | 700 | 1.0 | normal | Price points |
| Micro Label | Inter | 11px | 700 | 1.0 | 0.05em | `text-transform: uppercase` |

## 4. Component Stylings

### Buttons
- **Primary Dark**: Background `#111111`, Text `#ffffff`, Radius 4px, Padding 12px 32px.
- **Ghost Technical**: Transparent, Border 1px solid `#e0e0e0`, Radius 4px.
- **Secondary Dark**: Background `#333333`, Text `#ffffff`, Radius 4px.

### Product Cards & Containers
- **Surface**: `#ffffff` background, 8px radius.
- **Image Tray**: `#f6f6f6` inner container for products, 4px radius.
- **Shadow**: `0 4px 12px rgba(0,0,0,0.03)` base; `0 8px 24px rgba(0,0,0,0.06)` hover.
- **Badges**: `#e21b1b` background, 11px Inter Bold Uppercase text.

### Navigation & Header
- **Header**: Sticky white background, thin border-bottom `#e0e0e0`.
- **Search**: Minimalist stroke-only input with Inter 14px Weight 400.
- **Menu**: Text-based nav with 500 weight, subtle underline on hover.

## 5. Layout Principles
- **Editorial Pacing**: Sections alternate between dark "vibe" blocks and white "shop" blocks.
- **Grid Structure**: Standard 12-column grid; 4-column product display (3-column on small desktop).
- **Whitespace Strategy**: High vertical margins (80px–120px) to simulate a luxury print catalog.

## 6. Depth & Elevation

| Level | Treatment | Use |
|-------|-----------|-----|
| Level 0 | Flat Background | Main body and Hero sections |
| Level 1 | 1px border (`#e0e0e0`) | Product card definition, Inputs |
| Level 2 | `0 8px 24px rgba(0,0,0,0.06)` | Product card hover state |
| Level 3 | `0 12px 32px rgba(0,0,0,0.12)` | Cart drawers and modals |

## 7. Do's and Don'ts

### Do
- Use **isolated photography** for products on `#f6f6f6` backgrounds.
- Keep border radii sharp (4px–8px); only use 50% for status dots/icons.
- Use negative tracking (-0.02em) on large headlines for an industrial look.
- Apply Signal Red (`#e21b1b`) sparingly as a technical status color.

### Don't
- Don't use vibrant gradients or soft pastels; stick to the "Onyx/Alabaster" scheme.
- Don't use Serif fonts; they clash with the engineering aesthetic.
- Don't use thin font weights for headings; 600–700 minimum.
- Don't use heavy drop shadows; depth should come from contrast and borders.

## 8. Responsive Behavior
- **Desktop (1440px)**: 4-column product grid, full navigation.
- **Tablet (768px–1024px)**: 2-column grid, centered hero text.
- **Mobile (<768px)**: 1-column grid, full-bleed imagery, hidden search overlay.

## 9. Agent Prompt Guide

### Quick Color Reference
- Background (Dark): `#111111`
- Background (Light): `#ffffff`
- Product Tray: `#f6f6f6`
- Primary Text: `#000000` (on white) / `#ffffff` (on black)
- Accent: Signal Red (`#e21b1b`)

### Example Component Prompts
- "Create a product specimen card: `#f6f6f6` square image container with 4px radius, `#ffffff` bottom content area. 18px Inter Semibold title, 15px Bold price. 1px light-gray border."
- "Design a technical hero: `#111111` background, 48px Inter Bold white title with -0.02em tracking. Primary button `#ffffff` with `#111111` text, 4px radius."
- "Build a category grid: 4 columns, each card having a light-gray inner-border and a micro-label at the top in uppercase 11px Inter Bold red text."
- "Create a technical spec table: White background, `#e0e0e0` thin horizontal dividers, Inter 13px weight 400 for keys, weight 700 for values."

### Iteration Guide
1. Start with high-contrast blocks — alternate black and white sections for pacing.
2. Isolate all product photos on gray pedestals (`#f6f6f6`) to emphasize engineering.
3. Use Signal Red (`#e21b1b`) only for "Live" or "Sale" status markers.
4. Keep corners sharp (4px–8px) to maintain an industrial feel.
5. Use geometric sans-serifs (Inter/Satoshi) with bold weights (700) for all headings.

---

### **Upgrade Suggestions & Questions**

1.  **Palette Evolution**: Would you consider a **"Gunmetal Bronze"** accent (`#b5a075`) for a limited edition product line?
2.  **Typography Swap**: Should we introduce **"JetBrains Mono"** for small technical specs (Frequency, Impedance) to lean into the audiophile engineering vibe?
3.  **Background Depth**: Would a subtle **linear gradient** transition (`#111111` to `#1e1e1e`) on the hero add enough depth for the photography?
4.  **Interaction Design**: How about a **"Blueprint Overlay"** on hover, where a technical drawing appears over the product photo?
5.  **Micro-Interactions**: Should the "Add to Cart" button have a **haptic-style shrink animation** to mimic a high-end physical volume knob?