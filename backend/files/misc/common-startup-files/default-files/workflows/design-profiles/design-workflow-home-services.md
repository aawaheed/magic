# Design System: Home Services / Plumbing Business Landing Page
WORKFLOW ==> design-workflow-home-services

## 1. Visual Theme & Atmosphere
This design is a **vibrant, trust-oriented service portal** that uses high-energy color blocking to communicate reliability and speed. The interface operates on a "Safety First" aesthetic, dominated by **Construction Yellow** (`#fbd71a`) which immediately signals industrial service, maintenance, and visibility. The atmosphere is friendly and approachable rather than clinical, using soft rounded containers and "real-person" photography to lower the barrier for customer inquiries.

The design relies on **organic asymmetrical masks** (the large rounded yellow hero shape) to create a modern, non-corporate feel. It balances the high-intensity yellow with a deep **Navy Navy** (`#0b1c2c`) for structural elements like the top bar and primary CTAs, providing a grounded, professional anchor to the energetic palette.

**Key Characteristics:**
- High-intensity **Construction Yellow** color blocking for immediate industry recognition
- Navy structural anchors for a "Trusted Professional" voice
- Large-radius asymmetrical containers (top-left or bottom-right rounding)
- Action-oriented hero section with integrated person-focused photography
- Service-driven iconography: Circular icon badges with thin line-art
- Clean, high-contrast typography designed for quick scanning of services
- Card-based layouts with generous internal padding
- Emphasis on "Contact/Quote" conversion via persistent CTA buttons

## 2. Color Palette & Roles

### Brand Core
- **Construction Yellow** (`#fbd71a`): `--palette-bg-brand-primary`, Hero background, primary branding, secondary CTA surfaces
- **Deep Navy** (`#0b1c2c`): `--palette-bg-brand-secondary`, Top utility bar, primary buttons, footer text headings
- **Safety Orange** (`#e67e22`): Secondary accent for high-priority alerts or specific service highlights

### Surface & Accents
- **Pure White** (`#ffffff`): Main content surface and card backgrounds
- **Light Gray** (`#f9f9f9`): Section backgrounds for subtle visual separation
- **Border Gray** (`#eeeeee`): Form field outlines and dividers

### Text Scale
- **Industrial Black** (`#1a1a1a`): Primary heading and body text for maximum legibility
- **Navy Blue** (`#0b1c2c`): Button labels and header links for professional consistency
- **Muted Slate** (`#666666`): Secondary descriptions and meta-copy

## 3. Typography Rules

### Font Family
- **Primary**: `Montserrat` or `Poppins` (Rounded Sans-Serif), fallbacks: `Roboto, Arial, sans-serif`
- **Style**: High-legibility geometric sans-serif with a friendly, modern tone

### Hierarchy

| Role | Font | Size | Weight | Line Height | Letter Spacing | Notes |
|------|------|------|--------|-------------|----------------|-------|
| Hero Heading | Montserrat | 42px | 800 | 1.1 | -0.01em | Massive, high-impact titles |
| Section Title | Montserrat | 32px | 700 | 1.2 | normal | Primary content breaks |
| Card Title | Montserrat | 20px | 700 | 1.3 | normal | Service names |
| Nav Link | Montserrat | 14px | 500 | 1.0 | 0.02em | Navigation & utility links |
| Body Copy | Montserrat | 16px | 400 | 1.6 | normal | Service descriptions |
| CTA Label | Montserrat | 15px | 600 | 1.0 | normal | Buttons and form labels |
| Small Label | Montserrat | 12px | 700 | 1.2 | 0.05em | `text-transform: uppercase` |

### Principles
- **Bold Authority**: Headings are set to 700–800 weight to project confidence and expertise.
- **Scanning Clarity**: Tight line-height on headings ensures they act as solid visual anchors.
- **Approachable Spacing**: Body copy line-height (1.6) ensures the text feels easy to read for all demographics.

## 4. Component Stylings

### Buttons
- **Primary Action (Dark)**: Background `#0b1c2c`, White text, 20px+ radius (pill-shaped), subtle drop shadow.
- **Secondary Action (Light)**: Background `#ffffff` or Transparent, `#0b1c2c` text, 20px+ radius.
- **Conversion Button (Yellow)**: Background `#fbd71a`, Navy text, prominent in the header.

### Cards & Images
- **Hero Image**: Large photo with an asymmetrical mask (one sharp corner, others rounded).
- **Service Icons**: `#fbd71a` circular backgrounds with minimal black icons, centered over text.
- **Content Cards**: White background, 16px radius, subtle border or `0 2px 10px rgba(0,0,0,0.05)` shadow.

### Inputs & Forms
- **Field Style**: Pure white background, 1px solid gray border, 4px radius.
- **Submit Button**: High-contrast Navy with bold white text.

## 5. Layout Principles
- **The "Curve" Language**: Large, sweeping rounded corners on the Yellow hero section to draw the eye toward the CTA.
- **Vertical Hierarchy**: Top Utility Bar → Branding/Nav → High-Impact Hero → Service Icons → Detailed Services → Footer Form.
- **Whitespace Strategy**: Generous vertical padding between sections (100px+) to ensure the "Utility" brand doesn't feel cluttered.

## 6. Depth & Elevation

| Level | Treatment | Use |
|-------|-----------|-----|
| Level 0 | Flat Surface | Yellow and Light Gray backgrounds |
| Level 1 | 1px border or subtle tint | Image containers and Form inputs |
| Level 2 | `0 4px 15px rgba(0,0,0,0.08)` | Primary buttons and floating cards |
| Level 3 | `0 10px 25px rgba(0,0,0,0.12)` | Active CTA buttons and conversion forms |

## 7. Do's and Don'ts

### Do
- Use **person-centric photography** (service providers in uniform) to build trust.
- Keep the **Construction Yellow** as the dominant background color for the hero.
- Use **Deep Navy** for all primary text and actionable buttons.
- Apply **large-radius rounding** (20px to 40px) on major containers.
- Use high-contrast icons to represent services (Emergency, Residential, etc.).

### Don't
- Don't use thin font weights for titles; the brand must feel "Heavy Duty."
- Don't mix sharp-cornered images with rounded containers; keep the "soft" geometry consistent.
- Don't use red for buttons (clashes with yellow/service context); use Navy or Black.
- Don't hide the "Contact" or "Quote" info; it should be the most visible element.

## 8. Responsive Behavior
- **Desktop**: Asymmetrical hero layout with text on the left, person on the right.
- **Tablet**: Stacked layout; service icons shift from 3-across to 2-across.
- **Mobile**: Hero background fills the full screen; image moves below text; buttons become full-width.

## 9. Agent Prompt Guide

### Quick Color Reference
- Primary Yellow: `#fbd71a`
- Action Navy: `#0b1c2c`
- Text Black: `#1a1a1a`
- Neutral White: `#ffffff`

### Example Component Prompts
- "Design a service hero: `#fbd71a` background with a bottom-right rounded mask (radius 80px). Large 42px Montserrat Bold text in `#1a1a1a`. Pill-shaped navy CTA button."
- "Create a service icon block: 60px circle in `#fbd71a`, minimalist black icon inside, 18px Bold Montserrat title below with 14px gray description."
- "Build a contact card: White background, 20px radius, 1px light-gray border. Navy heading, yellow sub-headings, and input fields with 4px radius."

### Iteration Guide
1. Lead with Yellow — it is the industry identifier.
2. Use Navy for "Trust" — apply it to the navigation, headings, and buttons.
3. Incorporate asymmetrical curves to make the service feel modern and fast.
4. Bold the typography (700+) to signal expertise and authority.
5. Use icons as secondary navigation to allow users to find their specific problem (Emergency, Plumbing, etc.) quickly.

---

### **Upgrade Suggestions & Questions**

1.  **Typography Depth**: Would you like to introduce a secondary font like **"Roboto Mono"** for technical data (e.g., "Available 24/7" or "Response Time: 30m") to add a "precision service" feel?
2.  **Interactive Elements**: Should we add a **"Status Indicator"** (glowing green dot) next to the "Call Now" button to show that technicians are currently active and available?
3.  **Color Polish**: Would adding a subtle **diagonal stripe pattern** (texture) to the Yellow background enhance the "industrial/construction" vibe?
4.  **Photography Style**: Should we use **cut-out images** (no background) for the service people in the hero section to make the asymmetrical yellow shape pop more?
5.  **Micro-Interactions**: How about a **smooth-scroll animation** for the "Get a Quote" button that leads directly to a pre-filled form at the bottom of the page?