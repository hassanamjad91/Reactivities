import { FC } from 'react'
import Nav from 'react-bootstrap/Nav'
import Navbar from 'react-bootstrap/Navbar'
import Container from 'react-bootstrap/Container'

const Navigation: FC = () =>
    <Navbar bg="dark" data-bs-theme="dark" sticky={'top'}>
        <Container>
            <Navbar.Brand href="#home">Reactivities</Navbar.Brand>
            <Nav className="me-auto">
                <Nav.Link href="#home">Activities</Nav.Link>
            </Nav>
        </Container>
    </Navbar>

export default Navigation