# Design Profile; High Contrast Dashboard
WORKFLOW ==> high-contrast-dashboard

## Summary
A data- and operations-first interface profile built for speed of scanning, strong hierarchy, dense utility, and practical clarity. It prioritizes legibility, statuses, tables, and workflows over decorative landing-page aesthetics.

## Best use cases
- admin dashboards
- analytics tools
- CRM systems
- ERP interfaces
- internal tools
- finance operations
- logistics apps

## Visual identity
- Mood: precise, efficient, clear
- Tone: operational, intelligent, no-nonsense
- Density: medium-high
- Contrast: high

## Typography
- Heading font: Inter
- Body font: Inter
- Monospace font: JetBrains Mono
- H1 size: clamp(2.1rem, 3vw, 2.8rem)
- H2 size: clamp(1.5rem, 2vw, 2rem)
- Body size: 14px
- Line height: 1.5
- Letter spacing: -0.015em for headings

## Color system
- Background: #0C111D
- Background secondary: #121A29
- Surface: #151F32
- Surface elevated: #1A2740
- Text primary: #F3F7FF
- Text secondary: #A7B4C9
- Accent primary: #5B8CFF
- Accent secondary: #35D6A5
- Border: rgba(255,255,255,0.10)
- Glow: rgba(91,140,255,0.12)
- Shadow: rgba(0,0,0,0.28)

## Spacing and layout
- Max content width: 1440px
- Section padding: 32px 24px
- Card padding: 18px
- Grid gap: 16px
- Border radius: 14px
- Border width: 1px

## Components
### Buttons
- Primary button: compact solid action button
- Secondary button: dark surface with border
- Hover: stronger contrast and light lift
- Radius: 12px
- Padding: 11px 16px

### Cards
- Background: muted dark panel
- Border: functional low-contrast border
- Shadow: minimal panel depth
- Blur: none
- Radius: 14px

### Forms
- Input background: #10192A
- Input border: rgba(255,255,255,0.12)
- Input text: #F3F7FF
- Input radius: 12px
- Focus state: brighter border with blue ring

### Navigation
- Height: 68px top nav or fixed sidebar shell
- Background: stable dark shell
- Border: section dividers and panel lines
- Link style: compact utility navigation
- CTA style: practical action buttons

## Motion
- Transition speed: 140ms
- Easing: cubic-bezier(0.2, 0.8, 0.2, 1)
- Hover effects: subtle contrast shift
- Scroll effects: minimal
- Glow animation: none
- Parallax: no

## Imagery direction
- Photography: rarely needed
- Illustration: charts, diagrams, system visuals
- 3D: no
- Backgrounds: muted panels and data surfaces
- Icons: compact, legible, system-first

## Do
- Maximize scanability
- Use status colors consistently
- Make tables feel first-class
- Keep controls predictable
- Support dense information without clutter

## Avoid
- decorative hero effects
- oversized typography in app views
- weak row contrast
- too many accent colors
- unnecessary motion

## Hero direction
If a dashboard marketing surface is needed, use KPI cards, workflow previews, and product proof rather than lifestyle imagery.

## Implementation notes
Use a strong app shell, visible grouping, clear table states, and consistent utility spacing. Charts and forms should feel native to the same system.

## Tokens
```json
{
  "fonts": {
    "heading": "Inter",
    "body": "Inter",
    "mono": "JetBrains Mono"
  },
  "colors": {
    "bg": "#0C111D",
    "bg2": "#121A29",
    "surface": "#151F32",
    "surface2": "#1A2740",
    "text": "#F3F7FF",
    "muted": "#A7B4C9",
    "accent": "#5B8CFF",
    "accent2": "#35D6A5",
    "border": "rgba(255,255,255,0.10)",
    "glow": "rgba(91,140,255,0.12)",
    "shadow": "rgba(0,0,0,0.28)"
  },
  "layout": {
    "maxWidth": "1440px",
    "sectionPadding": "32px 24px",
    "cardPadding": "18px",
    "gap": "16px",
    "radius": "14px",
    "borderWidth": "1px"
  },
  "motion": {
    "duration": "140ms",
    "easing": "cubic-bezier(0.2, 0.8, 0.2, 1)"
  }
}
```