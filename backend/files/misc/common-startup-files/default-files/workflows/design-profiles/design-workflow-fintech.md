# Design System: Fintech / Digital Banking Landing Page
WORKFLOW ==> design-workflow-fintech

## 1. Visual Theme & Atmosphere
The interface is a **modern, high-growth financial ecosystem** that prioritizes "Digital Fluency" and "Financial Optimism." It moves away from the traditional, stagnant blue of legacy banking into a high-energy **Lime Green** (`#a3e635`) and **Deep Forest** (`#064e3b`) palette. The atmosphere is tech-forward, utilizing **Neo-Glassmorphism** (frosted credit cards, translucent charts) to communicate transparency and security.

The design is built on a **dynamic dashboard aesthetic**, where abstract UI elements (graphs, cards, balances) serve as the primary visual interest. It utilizes **organic circular masks** and "floating" UI components to create a sense of weightlessness and ease—suggesting that managing complex money is, with this tool, effortless and fluid.

**Key Characteristics:**
- **High-Contrast "Spring" Palette**: Neon Lime and Deep Forest for a disruptive, modern vibe.
- **Glassmorphism 2.0**: Multi-layered, translucent credit cards with soft shadows.
- **Micro-Pill Navigation**: Small, rounded category tags (e.g., "Budget," "Plan") for UI filtering.
- **Social Proof Strip**: Clean, grayscale partner logos (Visa, Forbes) to anchor the "new" brand in "old" trust.
- **Abstract Data Visualization**: Bar charts and balance displays as hero content.
- **Soft-Focus Depth**: Background glows and circular gradients to create a three-dimensional digital space.
- **Dynamic Feature Cards**: Solid lime blocks with high-contrast dark iconography.

## 2. Color Palette & Roles

### Brand Core
- **Lime Neon** (`#a3e635`): `--palette-bg-brand-primary`, primary CTAs, active feature cards, and "Success" highlights.
- **Deep Forest** (`#064e3b`): `--palette-bg-brand-dark`, primary headings, "Talk to Expert" buttons, and structural anchors.
- **Pure White** (`#ffffff`): Main canvas and "Glass" card surfaces.
- **Smoke Gray** (`#f3f4f6`): Secondary section backgrounds.

### Banking Surfaces
- **Card Teal** (`#0d9488`): Primary credit card surface.
- **Card Lime** (`#84cc16`): Secondary credit card/active balance surface.
- **Onyx Dashboard** (`#111827`): Dark mode balance containers and "Start Managing" steps background.

### Text Scale
- **Charcoal Forest** (`#064e3b`): Primary text — softer than pure black, maintaining brand warmth.
- **Muted Sage** (`#4b5563`): Secondary descriptions and meta-data.
- **Action White** (`#ffffff`): Text on dark buttons and card surfaces.

## 3. Typography Rules

### Font Family
- **Primary**: `Outfit` or `Plus Jakarta Sans` (Modern Geometric Sans), fallbacks: `Inter, system-ui`.
- **Style**: High x-height, open apertures, and a "friendly-tech" personality.

### Hierarchy

| Role | Font | Size | Weight | Line Height | Letter Spacing | Notes |
|------|------|------|--------|-------------|----------------|-------|
| Hero Heading | Outfit | 46px | 700 | 1.15 | -0.02em | Powerful, tight titles |
| Section Title | Outfit | 34px | 700 | 1.2 | -0.01em | Feature-rich headings |
| Card Title | Outfit | 18px | 600 | 1.3 | normal | Dashboard categories |
| UI/Nav Link | Outfit | 14px | 500 | 1.0 | 0.01em | Functional links |
| Body Copy | Outfit | 16px | 400 | 1.5 | normal | Clarity-focused text |
| Balance Text | Outfit | 24px | 700 | 1.0 | normal | Financial data points |
| Pill Tag | Outfit | 12px | 600 | 1.0 | normal | Filter/category tags |

### Principles
- **Semantic Weight**: Using font weight (400 vs 700) to create a visual hierarchy within the same line (e.g., "financial **clarity**").
- **Financial Focus**: Data points like balances ($47,586.32) are always bold and high-contrast.
- **Clean Alignment**: Flush-left alignment for all hero copy to maintain a structured, "Accountant" level of order.

## 4. Component Stylings

### Buttons
- **Primary Action (Lime)**: Background `#a3e635`, `#064e3b` text, 32px (pill) radius.
- **Watch Video (Ghost)**: Transparent, `#064e3b` text with a 40px circular "Play" icon.
- **Micro-Pills**: 1px `#e5e7eb` border, transparent background, 14px radius.

### Cards & Depth
- **Feature Blocks**: Solid `#a3e635` background, sharp 16px radius, centered icons.
- **Credit Cards**: `backdrop-filter: blur(10px)`, 20px radius, subtle 2px white border ring.
- **Dashboard Section**: Deep `#111827` background, white text, 24px radius on the container.

### Visual Elements
- **Partner Strip**: Grayscale logos at 50% opacity to maintain secondary importance.
- **Iconography**: Outline-style in the header; solid-style in the feature cards.

## 5. Layout Principles
- **The "Floating" Hero**: Floating overlapping UI elements (cards, charts) to the right of the hero text.
- **Horizontal Filtering**: Use of pill-tags in a horizontal row to organize content without vertical clutter.
- **Step-by-Step Logic**: Vertical 1-2-3 list for conversion (Start Managing Your Money).
- **Z-Axis Design**: Using overlapping elements to create depth (Bar chart behind a Credit Card).

## 6. Depth & Elevation

| Level | Treatment | Use |
|-------|-----------|-----|
| Level 0 | Flat Surface | Pure white background |
| Level 1 | `rgba(0,0,0,0.02) 0px 2px 8px` | Micro-pill tags |
| Level 2 | `rgba(0,0,0,0.08) 0px 10px 30px` | Feature cards and Dashboard blocks |
| Level 3 | `rgba(0,0,0,0.15) 0px 20px 40px` | Floating glass credit cards (Hero) |

## 7. Do's and Don'ts

### Do
- Use **Lime Green** for all high-intent conversion moments.
- Create **Glassmorphic** effects for financial card UI elements.
- Mix **bold weights** and **regular weights** in the same headline to emphasize keywords.
- Keep icons minimal and technical.
- Use generous white space between the logo wall and the feature sections.

### Don't
- Don't use traditional "Banker Blue"; the brand is about disruption.
- Don't use heavy, solid shadows on text; depth belongs only to UI components.
- Don't mix too many colors; stick to Lime, Forest, and Dashboard Black.
- Don't use rounded corners less than 12px for cards; keep the "soft-tech" feel.

## 8. Responsive Behavior
- **Desktop**: Split hero (Text left, UI right). 3-column feature grid.
- **Tablet**: UI elements stack below hero text. 2-column feature grid.
- **Mobile**: Single-column vertical scroll. Sticky "Get Started" button in footer.

## 9. Agent Prompt Guide

### Quick Color Reference
- Accent Lime: `#a3e635`
- Deep Forest: `#064e3b`
- Dark UI: `#111827`
- Background: `#ffffff`

### Example Component Prompts
- "Design a fintech card: Frosted glass effect (`rgba(255,255,255,0.4)`), 20px radius, white balance text `$5,337`, lime green Visa logo in corner."
- "Create a hero headline: 46px Outfit Bold, `#064e3b` color. Emphasis text in `#a3e635`."
- "Build a dashboard container: `#111827` background, 24px radius, white Outfit 700 text for balances, neon lime '+' action button."
- "Design a pill-tag row: 5 tags, each with 1px light-gray border, 14px Outfit Medium text, 20px padding."

### Iteration Guide
1. Start with high-impact Lime Green — it signals the "New Finance" vibe.
2. Use Glassmorphism to represent "Transparency" in banking.
3. Keep the typography geometric and bold (Outfit/Plus Jakarta Sans).
4. Use the 3-step conversion list to simplify the onboarding process.
5. Layer charts and cards in the hero section to show the platform's utility at a glance.

---

### **Upgrade Suggestions & Questions**

1.  **Motion Design**: Should we add a **"parallax scroll"** effect to the hero cards so they move at different speeds, enhancing the 3D depth?
2.  **Typography Polish**: Would you like to introduce a **Monospaced font** (e.g., "JetBrains Mono") for credit card numbers and account balances to give it a "secure code" feel?
3.  **Color Variant**: How about a **"Night Mode"** toggle suggestion where the whole site flips to the Deep Forest (`#064e3b`) as the background and Lime as the text?
4.  **Data Interaction**: Should the bar charts in the hero be **animated on load** to show a growing savings trend?
5.  **Micro-Interactions**: Would you like to add a **"Hover-Tilt"** effect (perspective shift) to the credit cards so they react to the user's mouse movement?