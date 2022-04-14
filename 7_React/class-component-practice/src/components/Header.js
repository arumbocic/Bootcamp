import Button from "./Button";

const Header = () => {
  const onClick = () => {
    console.log("Click");
  };

  return (
    <header className="header">
      <h1>Customers</h1>
      <Button color="green" text="Add Customer" onClick={onClick} />
    </header>
  );
};

export default Header;
